using JabaUtilsLibrary.Connectivity.Defines;

namespace JabaUtilsLibrary.Connectivity.Dtos {
    public abstract class ServiceRequestDto : INetworkActivityDto {

        #region Properties

        public NetworkActivityBaseTypeEnum NetworkActivityBaseType => NetworkActivityBaseTypeEnum.SERVICE_REQUEST;

        #endregion

        #region Implement IBitConvertion

        public abstract int GetByteCount ();
        public abstract bool NextBytesToParams (byte[] bytes, ref int currentByteIndex);
        public abstract byte[] ToByteArray ();

        #endregion

        #region Internal Methods

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public override bool Equals (object obj) {
            if (obj is not ServiceRequestDto other)
                return false;

            return base.Equals (other)
                ;
        }

        #endregion

    }
}
