using JabaUtilsLibrary.Data;
using JabaUtilsLibrary.Data.BitConvertion;
using JabaUtilsLibrary.Data.DataStructs;
using System.Collections.Generic;

namespace JabaUtilsLibrary_UnitTest.Tests.Data {
    public class DataTest_BitConvertion {

        #region Sample Data

        #endregion

        #region Testing Methods

        private static void TestMethod_StringBitConvertion (string sampleData, StringFormatEnum stringFormat) {
            byte[] sampleBytes = [.. BitConvertionUtils.ToByteArray (sampleData, stringFormat)];

            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextBytesToString (sampleBytes, ref currentByteIndex, out string copyData));

            if (string.IsNullOrEmpty (sampleData)) {
                Assert.True (string.IsNullOrEmpty (copyData));
            } else {
                Assert.Equal (copyData, sampleData);
            }
            Assert.Equal (BitConvertionUtils.GetByteCount (sampleData, stringFormat), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextBytesToString (sampleBytes, ref currentByteIndex, out _));
        }

        #endregion

        #region Main Test

        [Fact]
        public void DataTest_BitConvertion_BoolArray () {
            bool[] sampleBitSet = [true, false, false, true,
                true, true, false, true];
            EightBitSet sampleData = EightBitSet.FromBoolArray (sampleBitSet);

            byte[] sampleBytes = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextByteToEightBitSet (sampleBytes, ref currentByteIndex, out EightBitSet copyData));

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (byte), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextByteToEightBitSet (sampleBytes, ref currentByteIndex, out _));
        }

        [Fact]
        public void DataTest_BitConvertion_Byte () {
            byte sampleData = 0xAD;

            byte[] sampleBytes = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextByte (sampleBytes, ref currentByteIndex, out byte copyData));

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (byte), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextByte (sampleBytes, ref currentByteIndex, out _));
        }

        [Fact]
        public void DataTest_BitConvertion_ULong () {
            ulong sampleData = 1544432uL;

            byte[] sampleBytes = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextBytesToULong (sampleBytes, ref currentByteIndex, out ulong copyData));

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (ulong), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextBytesToULong (sampleBytes, ref currentByteIndex, out _));
        }

        [Fact]
        public void DataTest_BitConvertion_Long () {
            long sampleData = -66699432L;

            byte[] sampleBytes = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextBytesToLong (sampleBytes, ref currentByteIndex, out long copyData));

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (long), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextBytesToLong (sampleBytes, ref currentByteIndex, out _));
        }

        [Fact]
        public void DataTest_BitConvertion_UInt () {
            uint sampleData = 4365u;

            byte[] sampleBytes = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextBytesToUInt (sampleBytes, ref currentByteIndex, out uint copyData));

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (uint), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextBytesToUInt (sampleBytes, ref currentByteIndex, out _));
        }

        [Fact]
        public void DataTest_BitConversion_Int () {
            int sampleData = -38453;

            byte[] sampleBytes = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextBytesToInt (sampleBytes, ref currentByteIndex, out int copyData));

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (int), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextBytesToInt (sampleBytes, ref currentByteIndex, out _));
        }

        [Fact]
        public void DataTest_BitConvertion_UShort () {
            ushort sampleData = 991;

            byte[] sampleBytes = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextBytesToUShort (sampleBytes, ref currentByteIndex, out ushort copyData));

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (ushort), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextBytesToUShort (sampleBytes, ref currentByteIndex, out _));
        }

        [Fact]
        public void DataTest_BitConvertion_Short () {
            short sampleData = -1299;

            byte[] sampleBytes = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextBytesToShort (sampleBytes, ref currentByteIndex, out short copyData));

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (short), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextBytesToShort (sampleBytes, ref currentByteIndex, out _));
        }

        [Fact]
        public void DataTest_BitConvertion_Double () {
            double sampleData = -1299.66812621d;

            byte[] sampleBytes = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextBytesToDouble (sampleBytes, ref currentByteIndex, out double copyData));

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (double), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextBytesToDouble (sampleBytes, ref currentByteIndex, out _));
        }

        [Fact]
        public void DataTest_BitConvertion_Float () {
            float sampleData = -12996.668f;

            byte[] sampleBytes = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextBytesToFloat (sampleBytes, ref currentByteIndex, out float copyData));

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (float), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextBytesToFloat (sampleBytes, ref currentByteIndex, out _));
        }

        [Fact]
        public void DataTest_BitConvertion_String_Full () {
            TestMethod_StringBitConvertion ("HELLO WORLD!!!", StringFormatEnum.UTF_8);
        }

        [Fact]
        public void DataTest_BitConvertion_String_Empty () {
            TestMethod_StringBitConvertion ("", StringFormatEnum.UTF_32);
        }

        [Fact]
        public void DataTest_BitConvertion_String_Null () {
            TestMethod_StringBitConvertion (null, StringFormatEnum.UNICODE);
        }

        [Fact]
        public void DataTest_BitConvertion_Array_Full () {
            
            string[] sampleData = ["alpha", "beta", "gamma", "delta", "epsilon"];
            StringFormatEnum stringFormat = StringFormatEnum.UTF_16;
            int byteCountFunc (string m) {
                return BitConvertionUtils.GetByteCount (m, stringFormat);
            }
            byte[] toByteArrayFunc (string m) {
                return BitConvertionUtils.ToByteArray (m, stringFormat);
            }

            byte[] sampleBytes = BitConvertionUtils.ToByteArray (sampleData, byteCountFunc, toByteArrayFunc);
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextBytesToArray (sampleBytes, ref currentByteIndex, out string[] copyData, BitConvertionUtils.NextBytesToString));

            Assert.True (ArrayUtils.CheckOrderedEquals (copyData, sampleData));
            Assert.Equal (BitConvertionUtils.GetByteCount (sampleData, byteCountFunc), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextBytesToArray (sampleBytes, ref currentByteIndex, out string[] _, BitConvertionUtils.NextBytesToString));
        }

        [Fact]
        public void DataTest_BitConvertion_Array_NonFull () {

            string[] sampleData = ["alpha", null, "gamma", null, "epsilon", null, null, "theta", "iota", null];
            StringFormatEnum stringFormat = StringFormatEnum.UTF_8;
            int byteCountFunc (string m) {
                return BitConvertionUtils.GetByteCount (m, stringFormat);
            }
            byte[] toByteArrayFunc (string m) {
                return BitConvertionUtils.ToByteArray (m, stringFormat);
            }

            byte[] sampleBytes = BitConvertionUtils.ToByteArray (sampleData, byteCountFunc, toByteArrayFunc);
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextBytesToArray (sampleBytes, ref currentByteIndex, out string[] copyData, BitConvertionUtils.NextBytesToString));

            Assert.True (ArrayUtils.CheckOrderedEquals (copyData, sampleData));
            Assert.Equal (BitConvertionUtils.GetByteCount (sampleData, byteCountFunc), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextBytesToArray (sampleBytes, ref currentByteIndex, out string[] _, BitConvertionUtils.NextBytesToString));
        }

        [Fact]
        public void DataTest_BitConvertion_List_Full () {

            List<string> sampleData = ["alpha", "beta", "gamma", "delta", "epsilon"];
            StringFormatEnum stringFormat = StringFormatEnum.UTF_32;
            int byteCountFunc (string m) {
                return BitConvertionUtils.GetByteCount (m, stringFormat);
            }
            byte[] toByteArrayFunc (string m) {
                return BitConvertionUtils.ToByteArray (m, stringFormat);
            }

            byte[] sampleBytes = BitConvertionUtils.ToByteArray (sampleData, byteCountFunc, toByteArrayFunc);
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextBytesToList (sampleBytes, ref currentByteIndex, out List<string> copyData, BitConvertionUtils.NextBytesToString));

            Assert.True (ListUtils.CheckOrderedEquals (copyData, sampleData));
            Assert.Equal (BitConvertionUtils.GetByteCount (sampleData, byteCountFunc), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextBytesToList (sampleBytes, ref currentByteIndex, out List<string> _, BitConvertionUtils.NextBytesToString));
        }

        [Fact]
        public void DataTest_BitConvertion_List_NonFull () {

            List<string> sampleData = ["alpha", null, "gamma", null, "epsilon", null, null, "theta", "iota", null];
            StringFormatEnum stringFormat = StringFormatEnum.UNICODE;
            int byteCountFunc (string m) {
                return BitConvertionUtils.GetByteCount (m, stringFormat);
            }
            byte[] toByteArrayFunc (string m) {
                return BitConvertionUtils.ToByteArray (m, stringFormat);
            }

            byte[] sampleBytes = BitConvertionUtils.ToByteArray (sampleData, byteCountFunc, toByteArrayFunc);
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextBytesToList (sampleBytes, ref currentByteIndex, out List<string> copyData, BitConvertionUtils.NextBytesToString));

            Assert.True (ListUtils.CheckOrderedEquals (copyData, sampleData));
            Assert.Equal (BitConvertionUtils.GetByteCount (sampleData, byteCountFunc), currentByteIndex);

            // Excess Read ERROR Detection.
            Assert.False (BitConvertionUtils.NextBytesToList (sampleBytes, ref currentByteIndex, out List<string> _, BitConvertionUtils.NextBytesToString));
        }

        #endregion

    }
}