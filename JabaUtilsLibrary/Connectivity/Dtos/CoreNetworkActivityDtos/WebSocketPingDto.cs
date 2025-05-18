using JabaUtilsLibrary.Connectivity.Defines;
using JabaUtilsLibrary.Data.BitConvertion;

namespace JabaUtilsLibrary.Connectivity.Dtos.CoreNetworkActivityDtos {
    public sealed class WebSocketPingDto : CoreNetworkActivityDto {

        #region Properties

        private static readonly StringFormatEnum _StringFormat = StringFormatEnum.UTF_8;

        public override NetworkActivityBaseTypeEnum NetworkActivityBaseType => NetworkActivityBaseTypeEnum.WEB_SOCKET;
        public override CoreNetworkActivityTypeEnum CoreNetworkActivityType => CoreNetworkActivityTypeEnum.WEB_SOCKET_PING;

        public string clientUuid = "";
        public string pingMessage = "";

        #endregion

        #region Implement IBitConvertion

        public override int GetByteCount () {
            return sizeof (CoreNetworkActivityTypeEnum) // Core Network Activity Type
                + BitConvertionUtils.GetByteCount (clientUuid, _StringFormat) // Client UUID
                + BitConvertionUtils.GetByteCount (pingMessage, _StringFormat) // Ping Message
                ;
        }

        public override bool NextBytesToParams (byte[] bytes, ref int currentByteIndex) {
            // Skip Network Activity Type (pre-defined)
            currentByteIndex += sizeof (CoreNetworkActivityTypeEnum);
            if (currentByteIndex >= bytes.Length)
                return false;

            // Client UUID
            if (!BitConvertionUtils.NextBytesToString (bytes, ref currentByteIndex, out clientUuid))
                return false;
            // Ping Message
            if (!BitConvertionUtils.NextBytesToString (bytes, ref currentByteIndex, out pingMessage))
                return false;

            return true;
        }

        public override byte[] ToByteArray () {
            byte[] byteArray = new byte[GetByteCount ()];
            int currentByteIndex = 0;

            // Network Activity Type
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray((uint)CoreNetworkActivityType), byteArray, ref currentByteIndex);
            // Client UUID
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray (clientUuid, _StringFormat), byteArray, ref currentByteIndex);
            // Ping Message
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray (pingMessage, _StringFormat), byteArray, ref currentByteIndex);

            return byteArray;
        }

        #endregion

        #region Internal Methods

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public override bool Equals (object obj) {
            if (!(obj is WebSocketPingDto other))
                return false;

            return base.Equals (other)
                && this.clientUuid.Equals (other.clientUuid)
                && this.pingMessage.Equals (other.pingMessage)
                ;
        }

        #endregion

    }
}
