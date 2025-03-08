using JabaUtilsLibrary.Data.BitConvertion;
using JabaUtilsLibrary.Data.DataStructs;

namespace JabaUtilsLibrary_UnitTest.Tests.Data {
    public class DataTest_BitConvertion {

        #region Testing Methods

        private static void TestMethod_StringBitConvertion (string sampleData) {
            byte[] sampleBytes = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentByteIndex = 0;
            Assert.True (BitConvertionUtils.NextBytesToString (sampleBytes, ref currentByteIndex, out string copyData));

            if (string.IsNullOrEmpty (sampleData)) {
                Assert.True (string.IsNullOrEmpty (copyData));
            } else {
                Assert.Equal (copyData, sampleData);
            }
            Assert.Equal (BitConvertionUtils.GetPacketSize (sampleData), currentByteIndex);

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
            TestMethod_StringBitConvertion ("HELLO WORLD!!!");
        }

        [Fact]
        public void DataTest_BitConvertion_String_Empty () {
            TestMethod_StringBitConvertion ("");
        }

        [Fact]
        public void DataTest_BitConvertion_String_Null () {
            TestMethod_StringBitConvertion (null);
        }

        #endregion

    }
}