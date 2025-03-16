using System;

namespace JabaUtilsLibrary.Connectivity.Defines {
    public enum FeedbackMessageTypeEnum : uint {

        NULL                            = 0x00000000,
        PREFIX_FILTER                   = 0xFFFF0000,

        // Types
        APPROVED                        = CoreNetworkActivityTypeEnum.FEEDBACK_MESSAGE_APPROVED,
        WAITING                         = CoreNetworkActivityTypeEnum.FEEDBACK_MESSAGE_WAITING,
        INFO                            = CoreNetworkActivityTypeEnum.FEEDBACK_MESSAGE_INFO,
        REJECTED                        = CoreNetworkActivityTypeEnum.FEEDBACK_MESSAGE_REJECTED,
        WARNING                         = CoreNetworkActivityTypeEnum.FEEDBACK_MESSAGE_WARNING,
        ERROR                           = CoreNetworkActivityTypeEnum.FEEDBACK_MESSAGE_ERROR,

    }
}
