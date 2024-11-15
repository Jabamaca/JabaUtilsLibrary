using System;
using System.Text;
using System.Collections.Generic;

namespace JabaUtilsLibrary.Data.Packeting {
    public static class DataPacketingUtils {

        #region Properties

        private const int BIT_COUNT_OF_BYTE = 8;

        #endregion

        #region Methods

        public static bool[] ByteToBoolArray (byte b) {
            bool[] result = new bool[BIT_COUNT_OF_BYTE];

            for (int i = 0; i < BIT_COUNT_OF_BYTE; i++)
                result[i] = (b & 0x01 << i) != 0;

            return result;
        }

        public static byte ByteFromBoolArray (bool[] source) {
            if (source.Length != BIT_COUNT_OF_BYTE)
                return 0x00;

            byte result = 0x00;
            for (int i = 0; i < BIT_COUNT_OF_BYTE; i++) {
                if (source[i]) {
                    result |= (byte)(0x01 << i);
                }
            }

            return result;
        }

        public static void BytesToBoolArray (byte[] bytes, int byteCount, ref int currentByteIndex, out bool[] boolArray) {
            if (byteCount <= 0) {
                boolArray = new bool[8 * byteCount];
                return;
            }

            boolArray = new bool[BIT_COUNT_OF_BYTE * byteCount];
            int boolIndex = 0;

            for (int i = 0; i < byteCount; i++) {
                byte boolByte = bytes[currentByteIndex];
                foreach (bool b in ByteToBoolArray (boolByte)) {
                    boolArray[boolIndex] = b;
                    boolIndex++;
                }
                currentByteIndex++;
            }
        }

        public static void AddBytesToArray (IEnumerable<byte> bytesToAdd, byte[] byteArray, ref int currentByteIndex) {
            foreach (byte byteToAdd in bytesToAdd) {
                AddByteToArray (byteToAdd, byteArray, ref currentByteIndex);
            }
        }

        public static void AddByteToArray (byte byteToAdd, byte[] byteArray, ref int currentByteIndex) {
            byteArray[currentByteIndex] = byteToAdd;
            currentByteIndex++;
        }

        public static void ExtractNextByteFromArray (byte[] bytes, ref int currentByteIndex, out byte outValue) {
            outValue = bytes[currentByteIndex];
            currentByteIndex++;
        }

        public static void BytesToUInt64 (byte[] bytes, ref int currentByteIndex, out ulong outValue) {
            outValue = BitConverter.ToUInt64 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (ulong);
        }

        public static void BytesToInt64 (byte[] bytes, ref int currentByteIndex, out long outValue) {
            outValue = BitConverter.ToInt64 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (long);
        }

        public static void BytesToUInt32 (byte[] bytes, ref int currentByteIndex, out uint outValue) {
            outValue = BitConverter.ToUInt32 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (uint);
        }

        public static void BytesToInt32 (byte[] bytes, ref int currentByteIndex, out int outValue) {
            outValue = BitConverter.ToInt32 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (int);
        }

        public static void BytesToUInt16 (byte[] bytes, ref int currentByteIndex, out ushort outValue) {
            outValue = BitConverter.ToUInt16 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (ushort);
        }

        public static void BytesToInt16 (byte[] bytes, ref int currentByteIndex, out short outValue) {
            outValue = BitConverter.ToInt16 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (short);
        }

        public static void BytesToDouble (byte[] bytes, ref int currentByteIndex, out double outValue) {
            outValue = BitConverter.ToDouble (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (double);
        }

        public static void BytesToString (byte[] bytes, int stringByteLength, ref int currentByteIndex, out string outValue) {
            outValue = Encoding.UTF8.GetString (bytes, currentByteIndex, stringByteLength);
            currentByteIndex += stringByteLength;
        }

        public static byte[] BytesFromString (string str) {
            return Encoding.UTF8.GetBytes (str);
        }

        #endregion

    }
}
