using System;
using System.Collections.Generic;
using System.Text;
using JabaUtilsLibrary.Data.DataStructs;

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

        #region EIGHT BIT SET Packeting (8-bit)

        public static bool NextByteToEightBitSet (byte[] bytes, ref int currentByteIndex, out EightBitSet outValue) {
            outValue = new ();
            if (currentByteIndex >= bytes.Length)
                return false;

            outValue.NextBytesToParams (bytes, ref currentByteIndex);
            return true;
        }

        public static byte[] ToByteArray (EightBitSet source) {
            return source.ToByteArray ();
        }

        #endregion

        #region BYTE Packeting (8-bit)

        public static bool NextByte (byte[] bytes, ref int currentByteIndex, out byte outValue) {
            outValue = 0x00;
            if (currentByteIndex >= bytes.Length)
                return false;

            outValue = bytes[currentByteIndex];
            currentByteIndex++;
            return true;
        }

        public static byte[] ToByteArray (byte source) {
            return [source];
        }

        #endregion

        #region U-LONG Packeting (64-bit)

        public static bool NextBytesToULong (byte[] bytes, ref int currentByteIndex, out ulong outValue) {
            outValue = 0uL;
            if (currentByteIndex >= bytes.Length)
                return false;

            outValue = BitConverter.ToUInt64 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (ulong);
            return true;
        }

        public static byte[] ToByteArray (ulong source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region LONG Packeting (64-bit)

        public static bool NextBytesToLong (byte[] bytes, ref int currentByteIndex, out long outValue) {
            outValue = 0L;
            if (currentByteIndex >= bytes.Length)
                return false;

            outValue = BitConverter.ToInt64 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (long);
            return true;
        }

        public static byte[] ToByteArray (long source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region U-INT Packeting (32-bit)

        public static bool NextBytesToUInt (byte[] bytes, ref int currentByteIndex, out uint outValue) {
            outValue = 0u;
            if (currentByteIndex >= bytes.Length)
                return false;

            outValue = BitConverter.ToUInt32 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (uint);
            return true;
        }

        public static byte[] ToByteArray (uint source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region INT Packeting (32-bit)

        public static bool NextBytesToInt (byte[] bytes, ref int currentByteIndex, out int outValue) {
            outValue = 0;
            if (currentByteIndex >= bytes.Length)
                return false;

            outValue = BitConverter.ToInt32 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (int);
            return true;
        }

        public static byte[] ToByteArray (int source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region U-SHORT Packeting (16-bit)

        public static bool NextBytesToUShort (byte[] bytes, ref int currentByteIndex, out ushort outValue) {
            outValue = 0;
            if (currentByteIndex >= bytes.Length)
                return false;

            outValue = BitConverter.ToUInt16 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (ushort);
            return true;
        }

        public static byte[] ToByteArray (ushort source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region SHORT Packeting (16-bit)

        public static bool NextBytesToShort (byte[] bytes, ref int currentByteIndex, out short outValue) {
            outValue = 0;
            if (currentByteIndex >= bytes.Length)
                return false;

            outValue = BitConverter.ToInt16 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (short);
            return true;
        }

        public static byte[] ToByteArray (short source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region DOUBLE Packeting (64-bit)

        public static bool NextBytesToDouble (byte[] bytes, ref int currentByteIndex, out double outValue) {
            outValue = 0d;
            if (currentByteIndex >= bytes.Length)
                return false;

            outValue = BitConverter.ToDouble (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (double);
            return true;
        }

        public static byte[] ToByteArray (double source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region FLOAT Packeting (64-bit)

        public static bool NextBytesToFloat (byte[] bytes, ref int currentByteIndex, out float outValue) {
            outValue = 0f;
            if (currentByteIndex >= bytes.Length)
                return false;

            outValue = BitConverter.ToSingle (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (float);
            return true;
        }

        public static byte[] ToByteArray (float source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region STRING Packeting (undefined bit size)

        public static int GetPacketSize (string source) {
            if (string.IsNullOrEmpty (source))
                return sizeof (int);

            byte[] stringBytes = Encoding.UTF8.GetBytes (source);
            return sizeof (int) + stringBytes.Length;
        }

        public static bool NextBytesToString (byte[] bytes, ref int currentByteIndex, out string outValue) {
            outValue = "";
            if (!NextBytesToInt (bytes, ref currentByteIndex, out int stringByteLength)) {
                return false;
            }

            if (stringByteLength > 0) {
                if (currentByteIndex >= bytes.Length) {
                    return false;
                }

                outValue = Encoding.UTF8.GetString (bytes, currentByteIndex, stringByteLength);
                currentByteIndex += stringByteLength;
            }

            return true;
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

        #endregion

    }
}