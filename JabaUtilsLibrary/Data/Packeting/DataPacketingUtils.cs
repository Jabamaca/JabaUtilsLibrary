using System;
using System.Text;
using System.Collections.Generic;

namespace JabaUtilsLibrary.Data.Packeting {
    public static class DataPacketingUtils {

        #region Properties

        private const int BIT_COUNT_OF_BYTE = 8;

        #endregion

        #region Methods

        #region Packeting Methods

        public static void AddBytesToArray (IEnumerable<byte> bytesToAdd, byte[] byteArray, ref int currentByteIndex) {
            foreach (byte byteToAdd in bytesToAdd) {
                AddByteToArray (byteToAdd, byteArray, ref currentByteIndex);
            }
        }

        public static void AddByteToArray (byte byteToAdd, byte[] byteArray, ref int currentByteIndex) {
            byteArray[currentByteIndex] = byteToAdd;
            currentByteIndex++;
        }

        #endregion

        #region Conversion Methods

        // **** BOOLEAN ARRAY (8-bit) Packeting

        public static void NextByteToBoolArray (byte[] bytes, ref int currentByteIndex, out bool[] outValue) {
            outValue = new bool[BIT_COUNT_OF_BYTE];
            byte currentByte = bytes[currentByteIndex];

            for (int i = 0; i < BIT_COUNT_OF_BYTE; i++)
                outValue[i] = (currentByte & 0x01 << i) != 0;
            currentByteIndex++;
        }

        public static byte GetByte (bool[] source) {
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

        // **** BYTE (8-bit) Packeting

        public static void NextByte (byte[] bytes, ref int currentByteIndex, out byte outValue) {
            outValue = bytes[currentByteIndex];
            currentByteIndex++;
        }

        // **** U-LONG (64-bit) Packeting

        public static void NextBytesToULong (byte[] bytes, ref int currentByteIndex, out ulong outValue) {
            outValue = BitConverter.ToUInt64 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (ulong);
        }

        public static byte[] GetBytes (ulong source) {
            return BitConverter.GetBytes (source);
        }

        // **** LONG (64-bit) Packeting

        public static void NextBytesToLong (byte[] bytes, ref int currentByteIndex, out long outValue) {
            outValue = BitConverter.ToInt64 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (long);
        }

        public static byte[] GetBytes (long source) {
            return BitConverter.GetBytes (source);
        }

        // **** U-INT (32-bit) Packeting

        public static void NextBytesToUInt (byte[] bytes, ref int currentByteIndex, out uint outValue) {
            outValue = BitConverter.ToUInt32 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (uint);
        }

        public static byte[] GetBytes (uint source) {
            return BitConverter.GetBytes (source);
        }

        // **** INT (32-bit) Packeting

        public static void NextBytesToInt (byte[] bytes, ref int currentByteIndex, out int outValue) {
            outValue = BitConverter.ToInt32 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (int);
        }

        public static byte[] GetBytes (int source) {
            return BitConverter.GetBytes (source);
        }

        // **** U-SHORT (16-bit) Packeting

        public static void NextBytesToUShort (byte[] bytes, ref int currentByteIndex, out ushort outValue) {
            outValue = BitConverter.ToUInt16 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (ushort);
        }

        public static byte[] GetBytes (ushort source) {
            return BitConverter.GetBytes (source);
        }

        // **** SHORT (16-bit) Packeting

        public static void NextBytesToShort (byte[] bytes, ref int currentByteIndex, out short outValue) {
            outValue = BitConverter.ToInt16 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (short);
        }

        public static byte[] GetBytes (short source) {
            return BitConverter.GetBytes (source);
        }

        // **** DOUBLE (64-bit) Packeting

        public static void NextBytesToDouble (byte[] bytes, ref int currentByteIndex, out double outValue) {
            outValue = BitConverter.ToDouble (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (double);
        }

        public static byte[] GetBytes (double source) {
            return BitConverter.GetBytes (source);
        }

        // **** STRING (undefined bit size) Packeting

        public static void NextBytesToString (byte[] bytes, ref int currentByteIndex, out string outValue) {
            outValue = "";
            NextBytesToInt (bytes, ref currentByteIndex, out int stringByteLength);

            if (stringByteLength > 0) {
                outValue = Encoding.UTF8.GetString (bytes, currentByteIndex, stringByteLength);
                currentByteIndex += stringByteLength;
            }
        }

        public static byte[] BytesFromString (string str) {
            if (string.IsNullOrEmpty (str))
                return [.. GetBytes(0)];

            byte[] stringBytes = Encoding.UTF8.GetBytes (str);
            byte[] lengthBytes = GetBytes (stringBytes.Length);
            return [.. lengthBytes, .. stringBytes];
        }

        #endregion

        #endregion

    }
}