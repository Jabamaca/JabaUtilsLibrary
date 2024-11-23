using JabaUtilsLibrary.Data;
using JabaUtilsLibrary.Data.Packeting;

namespace JabaUtilsLibrary_UnitTest.Tests.Data {
    public class DataTest_Packeting {

        #region Testing Methods

        private static void TestMethod_StringPacketing (string sampleData) {
            byte[] samplePacket = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentPacketIndex = 0;
            BitConvertionUtils.NextBytesToString (samplePacket, ref currentPacketIndex, out string copyData);

            if (string.IsNullOrEmpty (sampleData)) {
                Assert.True (string.IsNullOrEmpty (copyData));
            } else {
                Assert.Equal (copyData, sampleData);
            }
            Assert.Equal (BitConvertionUtils.GetPacketSize (sampleData), currentPacketIndex);
        }

        #endregion

        #region Main Test

        [Fact]
        public void DataTest_Packeting_BoolArray () {
            bool[] sampleBitSet = [true, false, false, true,
                true, true, false, true];
            EightBitSet sampleData = EightBitSet.FromBoolArray (sampleBitSet);

            byte[] samplePacket = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentPacketIndex = 0;
            BitConvertionUtils.NextByteToEightBitSet (samplePacket, ref currentPacketIndex, out EightBitSet copyData);

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (byte), currentPacketIndex);
        }

        [Fact]
        public void DataTest_Packeting_Byte () {
            byte sampleData = 0xAD;

            byte[] samplePacket = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentPacketIndex = 0;
            BitConvertionUtils.NextByte (samplePacket, ref currentPacketIndex, out byte copyData);

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (byte), currentPacketIndex);
        }

        [Fact]
        public void DataTest_Packeting_ULong () {
            ulong sampleData = 1544432uL;

            byte[] samplePacket = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentPacketIndex = 0;
            BitConvertionUtils.NextBytesToULong (samplePacket, ref currentPacketIndex, out ulong copyData);

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (ulong), currentPacketIndex);
        }

        [Fact]
        public void DataTest_Packeting_Long () {
            long sampleData = -66699432L;

            byte[] samplePacket = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentPacketIndex = 0;
            BitConvertionUtils.NextBytesToLong (samplePacket, ref currentPacketIndex, out long copyData);

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (long), currentPacketIndex);
        }

        [Fact]
        public void DataTest_Packeting_UInt () {
            uint sampleData = 4365u;

            byte[] samplePacket = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentPacketIndex = 0;
            BitConvertionUtils.NextBytesToUInt (samplePacket, ref currentPacketIndex, out uint copyData);

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (uint), currentPacketIndex);
        }

        [Fact]
        public void DataTest_Packeting_Int () {
            int sampleData = -38453;

            byte[] samplePacket = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentPacketIndex = 0;
            BitConvertionUtils.NextBytesToInt (samplePacket, ref currentPacketIndex, out int copyData);

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (int), currentPacketIndex);
        }

        [Fact]
        public void DataTest_Packeting_UShort () {
            ushort sampleData = 991;

            byte[] samplePacket = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentPacketIndex = 0;
            BitConvertionUtils.NextBytesToUShort (samplePacket, ref currentPacketIndex, out ushort copyData);

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (ushort), currentPacketIndex);
        }

        [Fact]
        public void DataTest_Packeting_Short () {
            short sampleData = -1299;

            byte[] samplePacket = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentPacketIndex = 0;
            BitConvertionUtils.NextBytesToShort (samplePacket, ref currentPacketIndex, out short copyData);

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (short), currentPacketIndex);
        }

        [Fact]
        public void DataTest_Packeting_Double () {
            double sampleData = -1299.66812621d;
            
            byte[] samplePacket = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentPacketIndex = 0;
            BitConvertionUtils.NextBytesToDouble (samplePacket, ref currentPacketIndex, out double copyData);

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (double), currentPacketIndex);
        }

        [Fact]
        public void DataTest_Packeting_Float () {
            float sampleData = -12996.668f;

            byte[] samplePacket = [.. BitConvertionUtils.ToByteArray (sampleData)];
            int currentPacketIndex = 0;
            BitConvertionUtils.NextBytesToFloat (samplePacket, ref currentPacketIndex, out float copyData);

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sizeof (float), currentPacketIndex);
        }

        [Fact]
        public void DataTest_Packeting_String_Full () {
            TestMethod_StringPacketing ("HELLO WORLD!!!");
        }

        [Fact]
        public void DataTest_Packeting_String_Empty () {
            TestMethod_StringPacketing ("");
        }

        [Fact]
        public void DataTest_Packeting_String_Null () {
            TestMethod_StringPacketing (null);
        }

        #endregion

    }
}
