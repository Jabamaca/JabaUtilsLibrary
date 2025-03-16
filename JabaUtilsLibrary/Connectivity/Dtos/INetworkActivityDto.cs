using JabaUtilsLibrary.Connectivity.Defines;
using JabaUtilsLibrary.Data.BitConvertion;

namespace JabaUtilsLibrary.Connectivity.Dtos {
    public interface INetworkActivityDto : IBitConvertion {

        #region Properties

        public NetworkActivityBaseTypeEnum NetworkActivityBaseType {
            get;
        }

        #endregion

    }
}
