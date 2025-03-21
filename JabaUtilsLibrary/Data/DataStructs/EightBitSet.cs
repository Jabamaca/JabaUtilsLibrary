using JabaUtilsLibrary.Data.BitConvertion;

namespace JabaUtilsLibrary.Data.DataStructs {
    public class EightBitSet : IBitConvertion {

        #region Properties

        private const int BIT_COUNT_OF_BYTE = 8;

        public readonly bool[] bits = new bool[BIT_COUNT_OF_BYTE];

        #endregion

        #region Constructors

        public static EightBitSet FromBoolArray (bool[] boolArray) {
            EightBitSet returnValue = new EightBitSet ();

            int arrayLength = boolArray.Length;
            for (int i = 0; i < BIT_COUNT_OF_BYTE && i < arrayLength; i++) {
                returnValue.bits[i] = boolArray[i];
            }

            return returnValue;
        }

        #endregion

        #region Implement IBitConvertion

        public int GetByteCount () {
            return sizeof (byte) // Bits
                ;
        }

        public bool NextBytesToParams (byte[] bytes, ref int currentByteIndex) {
            if (currentByteIndex >= bytes.Length)
                return false;

            byte currentByte = bytes[currentByteIndex];

            for (int i = 0; i < BIT_COUNT_OF_BYTE; i++)
                bits[i] = (currentByte & 0x01 << i) != 0;
            currentByteIndex++;

            return true;
        }

        public byte[] ToByteArray () {
            byte result = 0x00;
            for (int i = 0; i < BIT_COUNT_OF_BYTE; i++) {
                if (bits[i]) {
                    result |= (byte)(0x01 << i);
                }
            }

            return new byte[] { result };
        }

        #endregion

        #region Internal Methods

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public override bool Equals (object obj) {
            if (!(obj is EightBitSet other))
                return false;

            return ArrayUtils.CheckOrderedEquals (bits, other.bits)
                ;
        }

        #endregion

    }
}