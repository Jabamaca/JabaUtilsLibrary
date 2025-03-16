namespace JabaUtilsLibrary.Connectivity.Defines {
    public enum WebSocketHandshakeTypeEnum : byte {

        NULL                            = 0x00,
        SERVER_TO_CLIENT_SEND           = 0x11,
        SERVER_TO_CLIENT_RECEIVE        = 0x12,
        CLIENT_TO_SERVER_SEND           = 0x21,
        CLIENT_TO_SERVER_RECEIVE        = 0x22,

    }
}
