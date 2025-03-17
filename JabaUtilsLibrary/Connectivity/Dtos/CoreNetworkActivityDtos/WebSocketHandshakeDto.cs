using JabaUtilsLibrary.Connectivity.Defines;
using JabaUtilsLibrary.Data.BitConvertion;

namespace JabaUtilsLibrary.Connectivity.Dtos.CoreNetworkActivityDtos {
    public sealed class WebSocketHandshakeDto : CoreNetworkActivityDto {

        #region Properties

        private static readonly StringFormatEnum _StringFormat = StringFormatEnum.UTF_8;

        public override NetworkActivityBaseTypeEnum NetworkActivityBaseType => NetworkActivityBaseTypeEnum.WEB_SOCKET;
        public override CoreNetworkActivityTypeEnum CoreNetworkActivityType => CoreNetworkActivityTypeEnum.WEB_SOCKET_HANDSHAKE;

        public string clientUuid = "";
        public WebSocketHandshakeTypeEnum handshakeType = WebSocketHandshakeTypeEnum.NULL;

        #endregion

        #region Implement IBitConvertion

        public override int GetByteCount () {
            return sizeof (CoreNetworkActivityTypeEnum) // Core Network Activity Type
                + BitConvertionUtils.GetByteCount (clientUuid, _StringFormat) // Client UUID
                + sizeof (byte) // Handshake Type
                ;
        }

        public override bool NextBytesToParams (byte[] bytes, ref int currentByteIndex) {
            // Skip Core Network Activity Type (pre-defined)
            currentByteIndex += sizeof (CoreNetworkActivityTypeEnum);

            // Client UUID
            if (!BitConvertionUtils.NextBytesToString (bytes, ref currentByteIndex, out clientUuid))
                return false;
            // Handshake Type
            if (!BitConvertionUtils.NextByte (bytes, ref currentByteIndex, out byte handshakeTypeByte))
                return false;
            handshakeType = (WebSocketHandshakeTypeEnum)handshakeTypeByte;

            return true;
        }

        public override byte[] ToByteArray () {
            byte[] byteArray = new byte[GetByteCount ()];
            int currentByteIndex = 0;

            // Core Network Activity Type
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray ((uint)CoreNetworkActivityType), byteArray, ref currentByteIndex);
            // Client UUID
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray (clientUuid, _StringFormat), byteArray, ref currentByteIndex);
            // Handshake Type
            BitConvertionUtils.AddByteToByteArray ((byte)handshakeType, byteArray, ref currentByteIndex);

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

            return base.Equals (other)
                && this.clientUuid.Equals (other.clientUuid)
                && this.handshakeType.Equals (other.handshakeType)
                ;
        }

        #endregion
    }
}
