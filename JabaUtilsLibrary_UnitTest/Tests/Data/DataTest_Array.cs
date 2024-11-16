using JabaUtilsLibrary.Data;

namespace JabaUtilsLibrary_UnitTest.Tests.Data {
    public class DataTest_Array {

        #region Sample Data

        private readonly string[] sampleStringArray = ["alpha", "beta", "gamma", "delta", "epsilon"];
        private readonly string[] sampleStringArrayWithNull = ["alpha", null, null, "delta", null, "zeta"];

        #endregion

        #region Test Methods

        private static void TestMethod_CheckOrderedEquals<T> (T[] sampleList) {
            T[] sampleList1 = [.. sampleList,];
            T[] sampleList2 = [.. sampleList,];

            Assert.True (ArrayUtils.CheckOrderedEquals (sampleList1, sampleList2));

            // Manual shuffle.
            (sampleList2[1], sampleList2[0]) = (sampleList2[0], sampleList2[1]);
            (sampleList2[4], sampleList2[3]) = (sampleList2[3], sampleList2[4]);

            Assert.False (ArrayUtils.CheckOrderedEquals (sampleList1, sampleList2));
        }

        #endregion

        #region Main Tests

        [Fact]
        public void DataTest_Array_CheckOrderedEquals_Full () {
            TestMethod_CheckOrderedEquals (sampleStringArray);
        }

        [Fact]
        public void DataTest_Array_CheckOrderedEquals_WithNull () {
            TestMethod_CheckOrderedEquals (sampleStringArrayWithNull);
        }

        #endregion

    }
}
