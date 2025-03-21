namespace JabaUtilsLibrary.Data.BitConvertion {
    public interface IBitConvertion {

        #region Properties

        #endregion

        #region Methods

        int GetByteCount ();
        bool NextBytesToParams (byte[] bytes, ref int currentByteIndex);
        byte[] ToByteArray ();

        #endregion

    }
}
