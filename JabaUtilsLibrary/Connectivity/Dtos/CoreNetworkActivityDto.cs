using JabaUtilsLibrary.Connectivity.Defines;

namespace JabaUtilsLibrary.Connectivity.Dtos {
    public abstract class CoreNetworkActivityDto : INetworkActivityDto {

        #region Properties

        public abstract NetworkActivityBaseTypeEnum NetworkActivityBaseType {
            get;
        }

        public abstract CoreNetworkActivityTypeEnum CoreNetworkActivityType {
            get;
        }

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
            if (!(obj is CoreNetworkActivityDto other))
                return false;

            return this.NetworkActivityBaseType.Equals (other.NetworkActivityBaseType)
                && this.CoreNetworkActivityType.Equals (other.CoreNetworkActivityType);
        }

        #endregion

    }
}
