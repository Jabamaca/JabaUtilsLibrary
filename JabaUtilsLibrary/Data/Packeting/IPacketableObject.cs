namespace JabaUtilsLibrary.Data.Packeting {
    public interface IPacketableObject {

        #region Properties

        #endregion

        #region Methods

        public int GetPacketSize ();
        public void BytesToParams (byte[] bytes, ref int currentByteIndex);
        public byte[] BytesFromParams ();

        #endregion

    }
}
