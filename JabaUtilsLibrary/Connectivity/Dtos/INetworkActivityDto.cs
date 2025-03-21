using JabaUtilsLibrary.Connectivity.Defines;
using JabaUtilsLibrary.Data.BitConvertion;

namespace JabaUtilsLibrary.Connectivity.Dtos {
    public interface INetworkActivityDto : IBitConvertion {

        #region Properties

        NetworkActivityBaseTypeEnum NetworkActivityBaseType {
            get;
        }

        #endregion

    }
}
