using JabaUtilsLibrary.Connectivity.Defines;
using JabaUtilsLibrary.Connectivity.Dtos;
using JabaUtilsLibrary.Connectivity.Dtos.CoreNetworkActivityDtos;
using System;
using Xunit;

namespace JabaUtilsLibrary_UnitTest.Tests.Connectivity {
    public class ConnectivityTest_BitConvertion {

        #region Testing Methods

        private static void TestingMethod_DtoBitConvertion<T> (T sampleDto, T copyDto, T excessDto) where T : INetworkActivityDto {
            byte[] dtoBytes = sampleDto.ToByteArray ();
            int currentByteIndex = 0;

            Assert.True (copyDto.NextBytesToParams (dtoBytes, ref currentByteIndex));
            Assert.Equal (dtoBytes.Length, currentByteIndex);
            Assert.True (sampleDto.Equals (copyDto));

            Assert.False (excessDto.NextBytesToParams (dtoBytes, ref currentByteIndex));
        }

        #endregion

        #region Main Tests

        [Fact]
        public void ConnectivityTest_BitConvertion_FeedbackMessageDto () {
            FeedbackMessageDto sampleDto = new FeedbackMessageDto () {
                messageKeyCodeNumber = (uint)FeedbackMessageTypeEnum.INFO | 0x000012A4,
                clientUuid = "4de143c8-895e-4cef-9b92-e23b846a3707",
                messageTitle = "Query Info",
                messageContent = "The following options will dictate the outcome of the activity.",
                activityCodeNumber = 0x019994F2,
            };

            TestingMethod_DtoBitConvertion (sampleDto, new FeedbackMessageDto (), new FeedbackMessageDto ());
        }

        [Fact]
        public void ConnectivityTest_BitConvertion_WebSocketHandshakeDto () {
            WebSocketHandshakeDto sampleDto = new WebSocketHandshakeDto () {
                handshakeType = WebSocketHandshakeTypeEnum.CLIENT_TO_SERVER_SEND,
                clientUuid = Guid.NewGuid ().ToString (),
            };

            TestingMethod_DtoBitConvertion (sampleDto, new WebSocketHandshakeDto (), new WebSocketHandshakeDto ());
        }

        [Fact]
        public void ConnectivityTest_BitConvertion_WebSocketPingDto () {
            WebSocketPingDto sampleDto = new WebSocketPingDto () {
                clientUuid = "bf599ec4-f740-45ff-a3ed-3847a4b5e7c7",
                pingMessage = "Pinging..."
            };

            TestingMethod_DtoBitConvertion (sampleDto, new WebSocketPingDto (), new WebSocketPingDto ());
        }

        [Fact]
        public void ConnectivityTest_BitConvertion_WebSocketPongDto () {
            WebSocketPongDto sampleDto = new WebSocketPongDto () {
                pongMessage = "Pong, back to Client...",
            };

            TestingMethod_DtoBitConvertion (sampleDto, new WebSocketPongDto (), new WebSocketPongDto ());
        }

        #endregion

    }
}
