namespace JabaUtilsLibrary.Data.BitConvertion {

    public delegate int ByteCountFunc<T> (T source);
    public delegate bool NextBytesToDataFunc<T> (byte[] bytes, ref int currentByteIndex, out T outValue);
    public delegate byte[] ToByteArrayFunc<T> (T source);

}
