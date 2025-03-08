namespace JabaUtilsLibrary.Data.BitConvertion {
    public interface IBitConvertion {

        #region Properties

        #endregion

        #region Methods

        public int GetByteCount ();
        public bool NextBytesToParams (byte[] bytes, ref int currentByteIndex);
        public byte[] ToByteArray ();

        #endregion

    }
}
