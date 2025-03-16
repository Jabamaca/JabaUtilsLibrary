using JabaUtilsLibrary.Connectivity.Defines;
using JabaUtilsLibrary.Data.BitConvertion;

namespace JabaUtilsLibrary.Connectivity.Dtos.CoreNetworkActivityDtos {
    public sealed class WebSocketHandshakeDto : CoreNetworkActivityDto {

        #region Properties

        private static readonly StringFormatEnum _StringFormat = StringFormatEnum.UTF_8;

        public override NetworkActivityBaseTypeEnum NetworkActivityBaseType => NetworkActivityBaseTypeEnum.WEB_SOCKET;
        public override CoreNetworkActivityTypeEnum CoreNetworkActivityType => CoreNetworkActivityTypeEnum.WEB_SOCKET_HANDSHAKE;

        public WebSocketHandshakeTypeEnum handshakeType = WebSocketHandshakeTypeEnum.NULL;
        public string userUuid = "";

        #endregion

        #region Implement IBitConvertion

        public override int GetByteCount () {
            return sizeof (CoreNetworkActivityTypeEnum) // Core Network Activity Type
                + sizeof (byte) // Handshake Type
                + BitConvertionUtils.GetByteCount (userUuid, _StringFormat) // User UUID
                ;
        }

        public override bool NextBytesToParams (byte[] bytes, ref int currentByteIndex) {
            // Skip Core Network Activity Type (pre-defined)
            currentByteIndex += sizeof (CoreNetworkActivityTypeEnum);

            // Handshake Type
            if (!BitConvertionUtils.NextByte (bytes, ref currentByteIndex, out byte handshakeTypeByte))
                return false;
            handshakeType = (WebSocketHandshakeTypeEnum)handshakeTypeByte;
            // User UUID
            if (!BitConvertionUtils.NextBytesToString (bytes, ref currentByteIndex, out userUuid))
                return false;

            return true;
        }

        public override byte[] ToByteArray () {
            byte[] byteArray = new byte[GetByteCount ()];
            int currentByteIndex = 0;

            // Core Network Activity Type
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray ((uint)CoreNetworkActivityType), byteArray, ref currentByteIndex);
            // Handshake Type
            BitConvertionUtils.AddByteToByteArray ((byte)handshakeType, byteArray, ref currentByteIndex);
            // User UUID
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray (userUuid, _StringFormat), byteArray, ref currentByteIndex);

            return byteArray;
        }

        #endregion

        #region Methods

        #endregion

        #region Internal Methods

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public override bool Equals (object obj) {
            if (obj is not WebSocketHandshakeDto other)
                return false;

            return this.handshakeType.Equals (other.handshakeType)
                && this.userUuid.Equals (other.userUuid)
                ;
        }

        #endregion
    }
}
