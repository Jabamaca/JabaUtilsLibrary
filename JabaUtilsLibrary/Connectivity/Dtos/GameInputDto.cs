using JabaUtilsLibrary.Connectivity.Defines;

namespace JabaUtilsLibrary.Connectivity.Dtos {
    public abstract class GameInputDto : INetworkActivityDto {

        #region Properties

        public NetworkActivityBaseTypeEnum NetworkActivityBaseType => NetworkActivityBaseTypeEnum.GAME_INPUT;

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
            if (!(obj is  GameInputDto other))
                return false;

            return this.NetworkActivityBaseType.Equals (other.NetworkActivityBaseType)
                ;
        }

        #endregion

    }
}