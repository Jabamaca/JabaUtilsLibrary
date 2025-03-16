using System;

namespace JabaUtilsLibrary.Connectivity.Defines {
    public enum NetworkActivityBaseTypeEnum : uint {

        NULL                            = 0x00000000,
        PREFIX_FILTER                   = 0xFF000000,

        // Primitive Types
        WEB_SOCKET                      = 0xF0000000,
        FEEDBACK_MESSAGE                = 0xAC000000,
        GAME_INPUT                      = 0x11000000,
        GAME_EVENT                      = 0x12000000,
        FEATURE_INPUT                   = 0x21000000,
        FEATURE_EVENT                   = 0x22000000,
        SERVICE_INPUT                   = 0x32000000,
        SERVICE_EVENT                   = 0x33000000,

    }
}
