using JabaUtilsLibrary.Data;
using JabaUtilsLibrary.Data.Packeting;

namespace JabaUtilsLibrary_UnitTest.Tests.Data {
    public class DataTest_Packeting {

        #region Main Test

        [Fact]
        public void DataTest_Packeting_BoolArray () {
            bool[] sampleBoolArray = [true, false, false, true,
                true, true, false, true];

            byte[] samplePacket = [DataPacketingUtils.GetByte (sampleBoolArray)];
            int currentPacketIndex = 0;
            DataPacketingUtils.NextByteToBoolArray (samplePacket, ref currentPacketIndex, out bool[] copyBoolArray);

            Assert.True (ArrayUtils.CheckOrderedEquals (sampleBoolArray, copyBoolArray));
        }

        #endregion

    }
}
