using System;
using System.Collections.Generic;
using System.Text;

namespace JabaUtilsLibrary.Data.BitConvertion {
    public static class BitConvertionUtils {

        #region Methods

        #region Packeting Methods

        public static void AddBytesToByteArray (IEnumerable<byte> bytesToAdd, byte[] byteArray, ref int currentByteIndex) {
            foreach (byte byteToAdd in bytesToAdd) {
                AddByteToByteArray (byteToAdd, byteArray, ref currentByteIndex);
            }
        }

        public static void AddByteToByteArray (byte byteToAdd, byte[] byteArray, ref int currentByteIndex) {
            byteArray[currentByteIndex] = byteToAdd;
            currentByteIndex++;
        }

        #endregion

        #region Conversion Methods

        // **** EIGHT BIT SET (8-bit) Packeting

        public static void NextByteToEightBitSet (byte[] bytes, ref int currentByteIndex, out EightBitSet outValue) {
            outValue = new ();
            outValue.NextBytesToParams (bytes, ref currentByteIndex);
        }

        public static byte[] ToByteArray (EightBitSet source) {
            return source.ToByteArray ();
        }

        // **** BYTE (8-bit) Packeting

        public static void NextByte (byte[] bytes, ref int currentByteIndex, out byte outValue) {
            outValue = bytes[currentByteIndex];
            currentByteIndex++;
        }

        public static byte[] ToByteArray (byte source) {
            return [source];
        }

        // **** U-LONG (64-bit) Packeting

        public static void NextBytesToULong (byte[] bytes, ref int currentByteIndex, out ulong outValue) {
            outValue = BitConverter.ToUInt64 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (ulong);
        }

        public static byte[] ToByteArray (ulong source) {
            return BitConverter.GetBytes (source);
        }

        // **** LONG (64-bit) Packeting

        public static void NextBytesToLong (byte[] bytes, ref int currentByteIndex, out long outValue) {
            outValue = BitConverter.ToInt64 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (long);
        }

        public static byte[] ToByteArray (long source) {
            return BitConverter.GetBytes (source);
        }

        // **** U-INT (32-bit) Packeting

        public static void NextBytesToUInt (byte[] bytes, ref int currentByteIndex, out uint outValue) {
            outValue = BitConverter.ToUInt32 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (uint);
        }

        public static byte[] ToByteArray (uint source) {
            return BitConverter.GetBytes (source);
        }

        // **** INT (32-bit) Packeting

        public static void NextBytesToInt (byte[] bytes, ref int currentByteIndex, out int outValue) {
            outValue = BitConverter.ToInt32 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (int);
        }

        public static byte[] ToByteArray (int source) {
            return BitConverter.GetBytes (source);
        }

        // **** U-SHORT (16-bit) Packeting

        public static void NextBytesToUShort (byte[] bytes, ref int currentByteIndex, out ushort outValue) {
            outValue = BitConverter.ToUInt16 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (ushort);
        }

        public static byte[] ToByteArray (ushort source) {
            return BitConverter.GetBytes (source);
        }

        // **** SHORT (16-bit) Packeting

        public static void NextBytesToShort (byte[] bytes, ref int currentByteIndex, out short outValue) {
            outValue = BitConverter.ToInt16 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (short);
        }

        public static byte[] ToByteArray (short source) {
            return BitConverter.GetBytes (source);
        }

        // **** DOUBLE (64-bit) Packeting

        public static void NextBytesToDouble (byte[] bytes, ref int currentByteIndex, out double outValue) {
            outValue = BitConverter.ToDouble (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (double);
        }

        public static byte[] ToByteArray (double source) {
            return BitConverter.GetBytes (source);
        }

        // **** FLOAT (64-bit) Packeting

        public static void NextBytesToFloat (byte[] bytes, ref int currentByteIndex, out float outValue) {
            outValue = BitConverter.ToSingle (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (float);
        }

        public static byte[] ToByteArray (float source) {
            return BitConverter.GetBytes (source);
        }

        // **** STRING (undefined bit size) Packeting

        public static int GetPacketSize (string source) {
            if (string.IsNullOrEmpty (source))
                return sizeof (int);

            byte[] stringBytes = Encoding.UTF8.GetBytes (source);
            return sizeof (int) + stringBytes.Length;
        }

        public static void NextBytesToString (byte[] bytes, ref int currentByteIndex, out string outValue) {
            outValue = "";
            NextBytesToInt (bytes, ref currentByteIndex, out int stringByteLength);

            if (stringByteLength > 0) {
                outValue = Encoding.UTF8.GetString (bytes, currentByteIndex, stringByteLength);
                currentByteIndex += stringByteLength;
            }
        }

        public static byte[] ToByteArray (string source) {
            if (string.IsNullOrEmpty (source))
                return [.. ToByteArray (0)];

            byte[] stringBytes = Encoding.UTF8.GetBytes (source);
            byte[] lengthBytes = ToByteArray (stringBytes.Length);
            return [.. lengthBytes, .. stringBytes];
        }

        #endregion

        #endregion

    }
}