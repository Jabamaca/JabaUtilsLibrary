using JabaUtilsLibrary.Data.DataStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JabaUtilsLibrary.Data.BitConvertion {
    public static class BitConvertionUtils {

        #region Methods

        #region Bit Convertion Methods

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

        #region Convertion Methods

        #region EIGHT BIT SET Bit Convertion (8-bit)

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

        #region BYTE Bit Convertion (8-bit)

        public static bool NextByte (byte[] bytes, ref int currentByteIndex, out byte outValue) {
            if (currentByteIndex >= bytes.Length) {
                outValue = 0x00;
                return false;
            }

            outValue = bytes[currentByteIndex];
            currentByteIndex++;
            return true;
        }

        public static byte[] ToByteArray (byte source) {
            return [source];
        }

        #endregion

        #region U-LONG Bit Convertion (64-bit)

        public static bool NextBytesToULong (byte[] bytes, ref int currentByteIndex, out ulong outValue) {
            if (currentByteIndex >= bytes.Length) {
                outValue = 0uL;
                return false;
            }

            outValue = BitConverter.ToUInt64 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (ulong);
            return true;
        }

        public static byte[] ToByteArray (ulong source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region LONG Bit Convertion (64-bit)

        public static bool NextBytesToLong (byte[] bytes, ref int currentByteIndex, out long outValue) {
            if (currentByteIndex >= bytes.Length) {
                outValue = 0L;
                return false;
            }

            outValue = BitConverter.ToInt64 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (long);
            return true;
        }

        public static byte[] ToByteArray (long source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region U-INT Bit Convertion (32-bit)

        public static bool NextBytesToUInt (byte[] bytes, ref int currentByteIndex, out uint outValue) {
            if (currentByteIndex >= bytes.Length) {
                outValue = 0u;
                return false;
            }

            outValue = BitConverter.ToUInt32 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (uint);
            return true;
        }

        public static byte[] ToByteArray (uint source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region INT Bit Convertion (32-bit)

        public static bool NextBytesToInt (byte[] bytes, ref int currentByteIndex, out int outValue) {
            if (currentByteIndex >= bytes.Length) {
                outValue = 0;
                return false;
            }

            outValue = BitConverter.ToInt32 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (int);
            return true;
        }

        public static byte[] ToByteArray (int source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region U-SHORT Bit Convertion (16-bit)

        public static bool NextBytesToUShort (byte[] bytes, ref int currentByteIndex, out ushort outValue) {
            if (currentByteIndex >= bytes.Length) {
                outValue = 0;
                return false;
            }

            outValue = BitConverter.ToUInt16 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (ushort);
            return true;
        }

        public static byte[] ToByteArray (ushort source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region SHORT Bit Convertion (16-bit)

        public static bool NextBytesToShort (byte[] bytes, ref int currentByteIndex, out short outValue) {
            if (currentByteIndex >= bytes.Length){
                outValue = 0;
                return false;
            }

            outValue = BitConverter.ToInt16 (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (short);
            return true;
        }

        public static byte[] ToByteArray (short source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region DOUBLE Bit Convertion (64-bit)

        public static bool NextBytesToDouble (byte[] bytes, ref int currentByteIndex, out double outValue) {
            if (currentByteIndex >= bytes.Length) {
                outValue = 0d;
                return false;
            }

            outValue = BitConverter.ToDouble (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (double);
            return true;
        }

        public static byte[] ToByteArray (double source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region FLOAT Bit Convertion (64-bit)

        public static bool NextBytesToFloat (byte[] bytes, ref int currentByteIndex, out float outValue) {
            if (currentByteIndex >= bytes.Length) {
                outValue = 0f;
                return false;
            }

            outValue = BitConverter.ToSingle (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (float);
            return true;
        }

        public static byte[] ToByteArray (float source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region Char Bit Convertion (64-bit)

        public static bool NextBytesToChar (byte[] bytes, ref int currentByteIndex, out char outValue) {
            if (currentByteIndex >= bytes.Length) {
                outValue = '\u0000';
                return false;
            }

            outValue = BitConverter.ToChar (bytes, startIndex: currentByteIndex);
            currentByteIndex += sizeof (float);
            return true;
        }

        public static byte[] ToByteArray (char source) {
            return BitConverter.GetBytes (source);
        }

        #endregion

        #region STRING Bit Convertion (undefined bit size)

        public static int GetByteCount (string source, StringFormatEnum stringFormat) {
            int size = sizeof (StringFormatEnum)
                + sizeof (int)
                ;

            if (string.IsNullOrEmpty (source))
                return size;

            size += stringFormat switch {
                StringFormatEnum.UTF_8 => Encoding.UTF8.GetBytes (source).Length,
                StringFormatEnum.UTF_16 => Encoding.Unicode.GetBytes (source).Length,
                StringFormatEnum.UTF_32 => Encoding.UTF32.GetBytes (source).Length,
                _ => Encoding.Unicode.GetBytes (source).Length,
            };

            return size;
        }

        public static bool NextBytesToString (byte[] bytes, ref int currentByteIndex, out string outValue) {
            outValue = "";
            if (!NextByte (bytes, ref currentByteIndex, out byte stringFormatByte)) {
                return false;
            }
            var stringFormat = (StringFormatEnum)stringFormatByte;

            if (!NextBytesToInt (bytes, ref currentByteIndex, out int stringByteLength)) {
                return false;
            }

            if (stringByteLength > 0) {
                if (currentByteIndex >= bytes.Length) {
                    return false;
                }

                outValue = stringFormat switch {
                    StringFormatEnum.UTF_8 => Encoding.UTF8.GetString (bytes, currentByteIndex, stringByteLength),
                    StringFormatEnum.UTF_16 => Encoding.Unicode.GetString (bytes, currentByteIndex, stringByteLength),
                    StringFormatEnum.UTF_32 => Encoding.UTF32.GetString (bytes, currentByteIndex, stringByteLength),
                    _ => Encoding.Unicode.GetString (bytes, currentByteIndex, stringByteLength)
                };

                Encoding.UTF8.GetString (bytes, currentByteIndex, stringByteLength);
                currentByteIndex += stringByteLength;
            }

            return true;
        }

        public static byte[] ToByteArray (string source, StringFormatEnum stringFormat) {
            if (string.IsNullOrEmpty (source))
                return [(byte)stringFormat, .. ToByteArray (0)];

            byte[] stringBytes = stringFormat switch {
                StringFormatEnum.UTF_8 => Encoding.UTF8.GetBytes (source),
                StringFormatEnum.UTF_16 => Encoding.Unicode.GetBytes (source),
                StringFormatEnum.UTF_32 => Encoding.UTF32.GetBytes (source),
                _ => Encoding.Unicode.GetBytes (source),
            };
            byte[] lengthBytes = ToByteArray (stringBytes.Length);
            return [(byte)stringFormat, .. lengthBytes, .. stringBytes];
        }

        #endregion

        #region Data Structs Bit Convertion

        private static int BaseGetByteCount<T> (IEnumerable<T> source, ByteCountFunc<T> memberByteCountFunc) {
            int totalSize = sizeof (int) // Total Member Count
                + sizeof (int) // Null Member Count
                ;

            foreach (T sourceMember in source) {
                if (sourceMember == null) {
                    totalSize += sizeof (int); // Null Member Index
                    continue;
                }

                totalSize += memberByteCountFunc (sourceMember);
            }

            return totalSize;
        }

        private static byte[] BaseToByteArray<T> (IEnumerable<T> source, ByteCountFunc<T> memberByteCountFunc, ToByteArrayFunc<T> memberToByteArrayFunc, Func<int> countFunc) {
            int byteCount = BaseGetByteCount (source, memberByteCountFunc);
            byte[] byteArray = new byte[byteCount];
            int currentByteIndex = 0;

            AddBytesToByteArray (ToByteArray (countFunc ()), byteArray, ref currentByteIndex);

            // Check for Null Members
            int nullMemberCount = 0;
            int currentIndex = 0;
            List<int> nullIndexes = [];
            foreach (T sourceMember in source) {
                if (sourceMember == null) {
                    nullMemberCount++;
                    nullIndexes.Add (currentIndex);
                }

                currentIndex++;
            }

            // Add Null Member Counts and Indexes
            AddBytesToByteArray (ToByteArray (nullMemberCount), byteArray, ref currentByteIndex);
            foreach (int nullIndex in nullIndexes) {
                AddBytesToByteArray (ToByteArray (nullIndex), byteArray, ref currentByteIndex);
            }

            // Non-Null Member Convertions
            foreach (T sourceMember in source) {
                if (sourceMember == null)
                    continue;

                AddBytesToByteArray (memberToByteArrayFunc (sourceMember), byteArray, ref currentByteIndex);
            }

            return byteArray;
        }

        private static bool NextBytesToNullIndexes (byte[] bytes, ref int currentByteIndex, out int[] nullIndexes) {
            if (!NextBytesToInt (bytes, ref currentByteIndex, out int nullMemberCount)) {
                nullIndexes = [];
                return false;
            }

            nullIndexes = new int[nullMemberCount];
            for (int i = 0; i < nullMemberCount; i++) {
                if (!NextBytesToInt (bytes, ref currentByteIndex, out int nullIndex)) {
                    nullIndexes = [];
                    return false;
                }

                nullIndexes[i] = nullIndex;
            }

            return true;
        }

        #region ARRAY Bit Convertion (undefined bit size)

        public static int GetByteCount<T> (T[] source, ByteCountFunc<T> memberByteCountFunc) {
            return BaseGetByteCount (source, memberByteCountFunc);
        }

        public static bool NextBytesToArray<T> (byte[] bytes, ref int currentByteIndex, out T[] outValue, NextBytesToDataFunc<T> nextBytesToMemberFunc) {
            if (!NextBytesToInt (bytes, ref currentByteIndex, out int arrayLength)) {
                outValue = [];
                return false;
            }

            if (!NextBytesToNullIndexes (bytes, ref currentByteIndex, out int[] nullIndexes)) {
                outValue = [];
                return false;
            }

            int nullMemberCount = nullIndexes.Length;
            int currentNullIndexIndex = 0;
            outValue = new T[arrayLength];

            for (int i = 0; i < arrayLength; i++) {
                if (currentNullIndexIndex < nullMemberCount && i == nullIndexes[currentNullIndexIndex]) {
                    currentNullIndexIndex++;
                    continue;
                }

                if (!nextBytesToMemberFunc (bytes, ref currentByteIndex, out T member)) {
                    outValue = [];
                    return false;
                }

                outValue[i] = member;
            }

            return true;
        }

        public static byte[] ToByteArray<T> (T[] source, ByteCountFunc<T> memberByteCountFunc, ToByteArrayFunc<T> memberToByteArrayFunc) {
            return BaseToByteArray (source, memberByteCountFunc, memberToByteArrayFunc, () => source.Length);
        }

        #endregion

        #region LIST Bit Convertion (undefined bit size)

        public static int GetByteCount<T> (List<T> source, ByteCountFunc<T> memberByteCountFunc) {
            return BaseGetByteCount (source, memberByteCountFunc);
        }

        public static bool NextBytesToList<T> (byte[] bytes, ref int currentByteIndex, out List<T> outValue, NextBytesToDataFunc<T> nextBytesToMemberFunc) {
            if (!NextBytesToInt (bytes, ref currentByteIndex, out int listCount)) {
                outValue = [];
                return false;
            }

            if (!NextBytesToNullIndexes (bytes, ref currentByteIndex, out int[] nullIndexes)) {
                outValue = [];
                return false;
            }

            int nullMemberCount = nullIndexes.Length;
            int currentNullIndexIndex = 0;
            T[] valueArray = new T[listCount];

            for (int i = 0; i < listCount; i++) {
                if (currentNullIndexIndex < nullMemberCount && i == nullIndexes[currentNullIndexIndex]) {
                    currentNullIndexIndex++;
                    continue;
                }

                if (!nextBytesToMemberFunc (bytes, ref currentByteIndex, out T member)) {
                    outValue = [];
                    return false;
                }

                valueArray[i] = member;
            }

            outValue = [.. valueArray];
            return true;
        }

        public static byte[] ToByteArray<T> (List<T> source, ByteCountFunc<T> memberByteCountFunc, ToByteArrayFunc<T> memberToByteArrayFunc) {
            return BaseToByteArray (source, memberByteCountFunc, memberToByteArrayFunc, () => source.Count);
        }

        #endregion

        #region DICTIONARY Bit Convertion (undefined bit size)

        public static int GetByteCount<K, V> (Dictionary<K, V> source, ByteCountFunc<K> keyByteCountFunc, ByteCountFunc<V> valueByteCountFunc) {
            int totalSize = sizeof (int) // Total Member Count
                + sizeof (int) // Null Value Count
                ;

            foreach (var sourceKvp in source) {
                totalSize += keyByteCountFunc (sourceKvp.Key);

                if (sourceKvp.Value == null) {
                    totalSize += sizeof (int); // Null Value Index
                    continue;
                }

                totalSize += valueByteCountFunc (sourceKvp.Value);
            }

            return totalSize;
        }

        public static bool NextBytesToDictionary<K, V> (byte[] bytes, ref int currentByteIndex, out Dictionary<K, V> outValue, NextBytesToDataFunc<K> nextBytesToKeyFunc, NextBytesToDataFunc<V> nextBytesToValueFunc) {
            outValue = [];
            if (!NextBytesToInt (bytes, ref currentByteIndex, out int arraySize)) {
                return false;
            }

            if (!NextBytesToNullIndexes (bytes, ref currentByteIndex, out int[] nullIndexes)) {
                return false;
            }

            int nullMemberCount = nullIndexes.Length;
            int currentNullIndexIndex = 0;

            for (int i = 0; i < arraySize; i++) {
                if (!nextBytesToKeyFunc (bytes, ref currentByteIndex, out K key)) {
                    return false;
                }

                if (currentNullIndexIndex < nullMemberCount && i == nullIndexes[currentNullIndexIndex]) {
                    currentNullIndexIndex++;
                    continue;
                }

                if (!nextBytesToValueFunc (bytes, ref currentByteIndex, out V value)) {
                    return false;
                }

                outValue.Add (key, value);
            }

            return true;
        }

        public static byte[] ToByteArray<K, V> (Dictionary<K, V> source, ByteCountFunc<K> keyByteCountFunc, ByteCountFunc<V> valueByteCountFunc, ToByteArrayFunc<K> keyToByteArrayFunc, ToByteArrayFunc<V> valueToByteArrayFunc) {
            int byteCount = GetByteCount (source, keyByteCountFunc, valueByteCountFunc);
            byte[] byteArray = new byte[byteCount];
            int currentByteIndex = 0;

            var sourceKvps = source.ToList ();

            AddBytesToByteArray (ToByteArray (byteCount), byteArray, ref currentByteIndex);

            // Check for Null Members
            int nullMemberCount = 0;
            int currentIndex = 0;
            List<int> nullIndexes = [];
            foreach (var sourceKvp in sourceKvps) {
                if (sourceKvp.Value == null) {
                    nullMemberCount++;
                    nullIndexes.Add (currentIndex);
                }

                currentIndex++;
            }

            // Add Null Member Counts and Indexes
            AddBytesToByteArray (ToByteArray (nullMemberCount), byteArray, ref currentByteIndex);
            foreach (int nullIndex in nullIndexes) {
                AddBytesToByteArray (ToByteArray (nullIndex), byteArray, ref currentByteIndex);
            }

            foreach (var sourceKvp in sourceKvps) {
                AddBytesToByteArray (keyToByteArrayFunc (sourceKvp.Key), byteArray, ref currentByteIndex);

                if (sourceKvp.Value == null) {
                    continue;
                }

                AddBytesToByteArray (valueToByteArrayFunc (sourceKvp.Value), byteArray, ref currentByteIndex);
            }

            return byteArray;
        }

        #endregion

        #endregion

        #endregion

        #endregion

    }
}