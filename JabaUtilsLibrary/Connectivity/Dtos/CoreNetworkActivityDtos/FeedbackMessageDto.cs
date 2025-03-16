using JabaUtilsLibrary.Connectivity.Defines;
using JabaUtilsLibrary.Data.BitConvertion;

namespace JabaUtilsLibrary.Connectivity.Dtos.CoreNetworkActivityDtos {
    public sealed class FeedbackMessageDto : CoreNetworkActivityDto {

        #region Properties

        private static readonly StringFormatEnum _StringFormat = StringFormatEnum.UTF_8;

        public override NetworkActivityBaseTypeEnum NetworkActivityBaseType => NetworkActivityBaseTypeEnum.FEEDBACK_MESSAGE;
        public override CoreNetworkActivityTypeEnum CoreNetworkActivityType => (CoreNetworkActivityTypeEnum)FeedbackMessageType;

        public FeedbackMessageTypeEnum FeedbackMessageType => (FeedbackMessageTypeEnum)(messageKeyCodeNumber & (uint)FeedbackMessageTypeEnum.PREFIX_FILTER);

        public uint messageKeyCodeNumber = 0;
        public string playerUuid = "";
        public string messageTitle = "";
        public string messageContent = "";
        public uint activityCodeNumber = 0;

        #endregion

        #region Constructors

        #endregion

        #region Implement IBitConvertion

        public override int GetByteCount () {
            return sizeof (uint) // Message Key Code Number. (also Core Network Activity Type)
                + BitConvertionUtils.GetByteCount (playerUuid, _StringFormat) // Player UUID
                + BitConvertionUtils.GetByteCount (messageTitle, _StringFormat) // Message Title
                + BitConvertionUtils.GetByteCount (messageContent, _StringFormat) // Message Content
                + sizeof (uint) // Activity Code Number
                ;
        }

        public override bool NextBytesToParams (byte[] bytes, ref int currentByteIndex) {
            // Message Key Code Number. (also Core Network Activity Type)
            if (!BitConvertionUtils.NextBytesToUInt (bytes, ref currentByteIndex, out messageKeyCodeNumber)) 
                return false;
            // Player UUID
            if (!BitConvertionUtils.NextBytesToString (bytes, ref currentByteIndex, out playerUuid))
                return false;
            // Message Title
            if (!BitConvertionUtils.NextBytesToString (bytes, ref currentByteIndex, out messageTitle))
                return false;
            // Message Content
            if (!BitConvertionUtils.NextBytesToString (bytes, ref currentByteIndex, out messageContent))
                return false;
            // Activity Code Number
            if (!BitConvertionUtils.NextBytesToUInt (bytes, ref currentByteIndex, out activityCodeNumber))
                return false;

            return true;
        }

        public override byte[] ToByteArray () {
            byte[] byteArray = new byte[GetByteCount ()];
            int currentByteIndex = 0;

            // Message Key Code Number. (also Core Network Activity Type)
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray (messageKeyCodeNumber), byteArray, ref currentByteIndex);
            // Player UUID
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray (playerUuid, _StringFormat), byteArray, ref currentByteIndex);
            // Message Title
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray (messageTitle, _StringFormat), byteArray, ref currentByteIndex);
            // Message Content
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray (messageContent, _StringFormat), byteArray, ref currentByteIndex);
            // Activity Code Number
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray (activityCodeNumber), byteArray, ref currentByteIndex);

            return byteArray;
        }

        #endregion

        #region Internal Methods

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public override bool Equals (object obj) {
            if (obj is not FeedbackMessageDto other)
                return false;

            return this.messageKeyCodeNumber.Equals (other.messageKeyCodeNumber)
                && this.playerUuid.Equals (other.playerUuid)
                && this.messageTitle.Equals (other.messageTitle)
                && this.messageContent.Equals (other.messageContent)
                && this.activityCodeNumber.Equals (other.activityCodeNumber)
                ;
        }

        #endregion

    }
}
