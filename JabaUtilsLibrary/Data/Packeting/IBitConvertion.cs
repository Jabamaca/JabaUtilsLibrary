namespace JabaUtilsLibrary.Data.Packeting {
    public interface IBitConvertion {

        #region Properties

        #endregion

        #region Methods

        public int GetByteCount ();
        public void NextBytesToParams (byte[] bytes, ref int currentByteIndex);
        public byte[] ToByteArray ();

        #endregion

    }
}
