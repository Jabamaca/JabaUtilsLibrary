using JabaUtilsLibrary.Connectivity.Defines;
using JabaUtilsLibrary.Connectivity.Dtos;
using JabaUtilsLibrary.Connectivity.Dtos.CoreNetworkActivityDtos;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace JabaUtilsLibrary.Connectivity {
    public class NetworkActivityDtoFactory {

        #region Properties

        public delegate bool CustomNetworkActivityDtoFactoryFunc (byte[] dataBytes, ref int currentByteIndex, out INetworkActivityDto networkActivityDto);

        private readonly ConcurrentDictionary<NetworkActivityBaseTypeEnum, CustomNetworkActivityDtoFactoryFunc> _customFactoryFuncDict = [];

        #endregion

        #region Methods

        public bool AddCustomFactoryFunc (NetworkActivityBaseTypeEnum networkActivityBaseType, CustomNetworkActivityDtoFactoryFunc customFactoryFunc) {
            return _customFactoryFuncDict.TryAdd (networkActivityBaseType, customFactoryFunc);
        }

        public bool ProcessBytesToNetworkActivities (byte[] bytes, out List<INetworkActivityDto> networkActivities) {
            int dataLength = bytes.Length;
            int currentByteIndex = 0;
            networkActivities = [];

            while (currentByteIndex < dataLength) {
                uint networkActivityUInt = BitConverter.ToUInt32 (bytes, startIndex: currentByteIndex);
                NetworkActivityBaseTypeEnum networkActivityBaseType = (NetworkActivityBaseTypeEnum)(networkActivityUInt & (uint)NetworkActivityBaseTypeEnum.PREFIX_FILTER);
                INetworkActivityDto networkActivity;

                switch (networkActivityBaseType) {
                    case NetworkActivityBaseTypeEnum.NULL:
                    case NetworkActivityBaseTypeEnum.PREFIX_FILTER: {
                        return false; // ERROR: Corrupted Data. Invalid Type Detected
                    }
                    case NetworkActivityBaseTypeEnum.WEB_SOCKET: {
                        if (!ProcessBytesToWebSocketActivity (bytes, ref currentByteIndex, out networkActivity))
                            return false; // ERROR: Corrupted Data. Invalid Type Detected
                        break;
                    }
                    case NetworkActivityBaseTypeEnum.FEEDBACK_MESSAGE: {
                        if (!ProcessBytesToFeedbackMessage (bytes, ref currentByteIndex, out networkActivity))
                            return false; // ERROR: Corrupted Data. Invalid Type Detected
                        break;
                    }
                    default: {
                        if (!ProcessBytesForCustomFactory (networkActivityBaseType, bytes, ref currentByteIndex, out networkActivity))
                            return false; // ERROR: Corrupted Data. Invalid Type Detected
                        break;
                    }
                }

                if (networkActivity == null)
                    return false;

                networkActivities.Add (networkActivity);
            }

            return true;

        }

        private static bool ProcessBytesToWebSocketActivity (byte[] bytes, ref int currentByteIndex, out INetworkActivityDto networkActivity) {
            uint coreNetworkActivityUInt = BitConverter.ToUInt32 (bytes, startIndex: currentByteIndex);
            CoreNetworkActivityTypeEnum coreNetworkActivityType = (CoreNetworkActivityTypeEnum)(coreNetworkActivityUInt & (uint)CoreNetworkActivityTypeEnum.PREFIX_FILTER);
            networkActivity = null;

            switch (coreNetworkActivityType) {
                case CoreNetworkActivityTypeEnum.WEB_SOCKET_HANDSHAKE:{
                    networkActivity = new WebSocketHandshakeDto ();
                    break;
                }
                case CoreNetworkActivityTypeEnum.WEB_SOCKET_PING: {
                    networkActivity = new WebSocketPingDto ();
                    break;
                }
                case CoreNetworkActivityTypeEnum.WEB_SOCKET_PONG: {
                    networkActivity = new WebSocketPongDto ();
                    break;
                }
                default: {
                    return false; // ERROR: Corrupted Data. Invalid Type Detected
                }
            }

            if (networkActivity == null)
                return false;

            return networkActivity.NextBytesToParams (bytes, ref currentByteIndex);
        }

        private static bool ProcessBytesToFeedbackMessage (byte[] bytes, ref int currentByteIndex, out INetworkActivityDto networkActivity) {
            networkActivity = new FeedbackMessageDto ();
            return networkActivity.NextBytesToParams (bytes, ref currentByteIndex);
        }

        private bool ProcessBytesForCustomFactory (NetworkActivityBaseTypeEnum networkActivityBaseType, byte[] dataBytes, ref int currentByteIndex, out INetworkActivityDto networkActivity) {
            if (!_customFactoryFuncDict.TryGetValue (networkActivityBaseType, out var customFactoryFunc) || customFactoryFunc == null) {
                networkActivity = null;
                return false; // ERROR: Corrupted Data. Invalid Type Detected
            }

            customFactoryFunc.Invoke (dataBytes, ref currentByteIndex, out networkActivity);
            return true;
        }

#pragma warning disable CA1822 // Mark members as static. (Disable warning for instance parallelism.)
        public byte[] ProcessNetworkActivitiesToBytes (IEnumerable<INetworkActivityDto> networkActivityDtos) {
            List<byte> bytesList = [];

            foreach (var networkActivityDto in networkActivityDtos) {
                bytesList.AddRange (networkActivityDto.ToByteArray ());
            }

            return [.. bytesList];
        }
#pragma warning restore CA1822 // Mark members as static.

        #endregion
    }
}
