using JabaUtilsLibrary.Connectivity.Defines;
using JabaUtilsLibrary.Data.BitConvertion;

namespace JabaUtilsLibrary.Connectivity.Dtos.CoreNetworkActivityDtos {
    public class WebSocketPongDto : CoreNetworkActivityDto {

        #region Properties

        private static readonly StringFormatEnum _StringFormat = StringFormatEnum.UTF_8;

        public override NetworkActivityBaseTypeEnum NetworkActivityBaseType => NetworkActivityBaseTypeEnum.WEB_SOCKET;
        public override CoreNetworkActivityTypeEnum CoreNetworkActivityType => CoreNetworkActivityTypeEnum.WEB_SOCKET_PONG;

        public string pongMessage = "";

        #endregion

        #region Implement IBitConvertion

        public override int GetByteCount () {
            return sizeof (CoreNetworkActivityTypeEnum) // Core Network Activity Type
                + BitConvertionUtils.GetByteCount (pongMessage, _StringFormat) // Pong Message
                ;
        }

        public override bool NextBytesToParams (byte[] bytes, ref int currentByteIndex) {
            // Skip Network Activity Type (pre-defined)
            currentByteIndex += sizeof (CoreNetworkActivityTypeEnum);

            // Pong Message
            if (!BitConvertionUtils.NextBytesToString (bytes, ref currentByteIndex, out pongMessage))
                return false;

            return true;
        }

        public override byte[] ToByteArray () {
            byte[] byteArray = new byte[GetByteCount ()];
            int currentByteIndex = 0;

            // Network Activity Type
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray ((uint)CoreNetworkActivityType), byteArray, ref currentByteIndex);
            // Ping Message
            BitConvertionUtils.AddBytesToByteArray (BitConvertionUtils.ToByteArray (pongMessage, _StringFormat), byteArray, ref currentByteIndex);

            return byteArray;
        }

        #endregion

        #region Internal Methods

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public override bool Equals (object obj) {
            if (obj is not WebSocketPongDto other)
                return false;

            return base.Equals (other)
                && this.pongMessage.Equals (other.pongMessage)
                ;
        }

        #endregion

    }
}
