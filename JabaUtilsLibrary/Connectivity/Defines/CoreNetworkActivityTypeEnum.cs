using System;

namespace JabaUtilsLibrary.Connectivity.Defines {
    public enum CoreNetworkActivityTypeEnum : uint {

        NULL                            = 0x00000000,
        PREFIX_FILTER                   = 0xFFFF0000,

        // Connection Activity
        WEB_SOCKET_                     = NetworkActivityBaseTypeEnum.WEB_SOCKET,
        WEB_SOCKET_HANDSHAKE            = WEB_SOCKET_ | 0x00AA0000,
        WEB_SOCKET_PING                 = WEB_SOCKET_ | 0x00FA0000,
        WEB_SOCKET_PONG                 = WEB_SOCKET_ | 0x00FB0000,

        // System Messages
        FEEDBACK_MESSAGE_               = NetworkActivityBaseTypeEnum.FEEDBACK_MESSAGE,
        FEEDBACK_MESSAGE_APPROVED       = FEEDBACK_MESSAGE_ | 0x00010000,
        FEEDBACK_MESSAGE_WAITING        = FEEDBACK_MESSAGE_ | 0x00020000,
        FEEDBACK_MESSAGE_INFO           = FEEDBACK_MESSAGE_ | 0x00110000,
        FEEDBACK_MESSAGE_REJECTED       = FEEDBACK_MESSAGE_ | 0x00410000,
        FEEDBACK_MESSAGE_WARNING        = FEEDBACK_MESSAGE_ | 0x00420000,
        FEEDBACK_MESSAGE_ERROR          = FEEDBACK_MESSAGE_ | 0x00440000,

    }
}
