using JabaUtilsLibrary.Connectivity.Defines;

namespace JabaUtilsLibrary.Connectivity.Dtos {
    public abstract class ServiceFeedbackDto : INetworkActivityDto {

        #region Properties

        public NetworkActivityBaseTypeEnum NetworkActivityBaseType => NetworkActivityBaseTypeEnum.SERVICE_FEEDBACK;

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
            if (!(obj is ServiceFeedbackDto other))
                return false;

            return base.Equals (other)
                ;
        }

        #endregion

    }
}
