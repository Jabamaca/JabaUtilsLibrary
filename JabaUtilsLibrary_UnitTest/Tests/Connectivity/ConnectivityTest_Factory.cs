using JabaUtilsLibrary.Connectivity.Defines;
using JabaUtilsLibrary.Connectivity.Dtos.CoreNetworkActivityDtos;
using JabaUtilsLibrary.Connectivity.Dtos;
using JabaUtilsLibrary.Connectivity;
using System.Collections.Generic;

namespace JabaUtilsLibrary_UnitTest.Tests.Connectivity {
    public class ConnectivityTest_Factory {

        #region Sample Data

        private static readonly NetworkActivityDtoFactory _networkActivityDtoFactory = new ();

        #endregion

        #region Testing Methods

        private static void TestingMethod_MakeSingle (INetworkActivityDto sampleDto) {
            byte[] dtoBytes = sampleDto.ToByteArray ();

            Assert.True (_networkActivityDtoFactory.ProcessBytesToNetworkActivities (dtoBytes, out var factoryMadeDtos));
            Assert.True (sampleDto.Equals (factoryMadeDtos[0])); // Only 1 entry Made
        }

        private static void TestingMethod_MakeList (List<INetworkActivityDto> sampleDtoList) {
            byte[] dtoBytes = _networkActivityDtoFactory.ProcessNetworkActivitiesToBytes (sampleDtoList);

            Assert.True (_networkActivityDtoFactory.ProcessBytesToNetworkActivities (dtoBytes, out var factoryMadeDtos));
            Assert.Equal (sampleDtoList.Count, factoryMadeDtos.Count);

            int dtoCount = sampleDtoList.Count;
            for (int i = 0; i < dtoCount; i++) {
                Assert.True (sampleDtoList[i].Equals (factoryMadeDtos[i]));
            }
        }

        #endregion

        #region Main Tests

        [Fact]
        public void ConnectivityTest_Factory_FeedbackMessageDto () {
            FeedbackMessageDto sampleDto = new () {
                messageKeyCodeNumber = (uint)FeedbackMessageTypeEnum.APPROVED | 0x00001395,
                clientUuid = "6aaf0c53-f1c9-4aff-b6bc-51ee9d05727a",
                messageTitle = "Game Input Approved",
                messageContent = "Game Input successfully processed.",
                activityCodeNumber = 0x0122AD5A,
            };

            TestingMethod_MakeSingle (sampleDto);
        }

        [Fact]
        public void ConnectivityTest_Factory_WebSocketHandshakeDto () {
            WebSocketHandshakeDto sampleDto = new () {
                clientUuid = "83a63b40-0915-4d52-b6e4-f10f100dbab7",
                handshakeType = WebSocketHandshakeTypeEnum.SERVER_TO_CLIENT_SEND,
            };

            TestingMethod_MakeSingle (sampleDto);
        }

        [Fact]
        public void ConnectivityTest_Factory_WebSocketPingDto () {
            WebSocketPingDto sampleDto = new () {
                clientUuid = "17752193-2a8d-4fb2-9fb8-52ec5eb42e1a",
                pingMessage = "Pinging..."
            };

            TestingMethod_MakeSingle (sampleDto);
        }

        [Fact]
        public void ConnectivityTest_Factory_NetworkActivityDtos_List () {
            List<INetworkActivityDto> networkActivityDtos = [
                new WebSocketHandshakeDto () {
                    clientUuid = "a3d47387-a028-461d-bb4f-9b1227e6072e",
                    handshakeType = WebSocketHandshakeTypeEnum.SERVER_TO_CLIENT_SEND,
                },
                new WebSocketPingDto () {
                    clientUuid = "17752193-2a8d-4fb2-9fb8-52ec5eb42e1a",
                    pingMessage = "Pinging..."
                },
                new FeedbackMessageDto () {
                    messageKeyCodeNumber = (uint)FeedbackMessageTypeEnum.APPROVED | 0x00000601,
                    clientUuid = "d5aac2f4-9ceb-4c25-93ac-6b2168f80363",
                    messageTitle = "Game Input Approved",
                    messageContent = "Game Input successfully processed.",
                    activityCodeNumber = 0x01211201,
                },
                new WebSocketPingDto () {
                    clientUuid = "b2344226-289b-4eed-9eea-57621bcb04fb",
                    pingMessage = "Pinging..."
                },
                new FeedbackMessageDto () {
                    messageKeyCodeNumber = (uint)FeedbackMessageTypeEnum.REJECTED | 0x00004611,
                    clientUuid = "27603f08-e4e5-4989-9e10-a73224c69ffb",
                    messageTitle = "Game Input Rejected",
                    messageContent = "Insufficient currency.",
                    activityCodeNumber = 0x01210512,
                },
                new FeedbackMessageDto () {
                    messageKeyCodeNumber = (uint)FeedbackMessageTypeEnum.WARNING | 0x0000013A,
                    clientUuid = "daf32841-627a-4328-9eff-53608d7c5468",
                    messageTitle = "Feature Input Warning",
                    messageContent = "Detected server traffic, transaction may take time.",
                    activityCodeNumber = 0x037A4312,
                },
                new WebSocketPingDto () {
                    clientUuid = "c6b713b7-6e8d-4859-a872-b70a6e5987b2",
                    pingMessage = "Pinging..."
                },
                new WebSocketPingDto () {
                    clientUuid = "f57f3b60-39e9-40c0-a63e-2c8da3f91581",
                    pingMessage = "Pinging..."
                },
            ];

            TestingMethod_MakeList (networkActivityDtos);
        }

        #endregion

    }
}
