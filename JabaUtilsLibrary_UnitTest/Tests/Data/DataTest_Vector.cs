using JabaUtilsLibrary.Data.BitConvertion;
using JabaUtilsLibrary.Data.DataStructs;
using JabaUtilsLibrary_UnitTest.TestObjects;

namespace JabaUtilsLibrary_UnitTest.Tests.Data {
    public class DataTest_Vector {

        #region Test Methods

        #endregion

        #region Main Test

        [Fact]
        public void DataTest_Vector2Double_Magnitude () {
            Vector2Double testVectorD = new (3d, 4d);

            Assert.True (TestUtils.TestPrecision (25d, testVectorD.SqrMagnitude ()));
            Assert.True (TestUtils.TestPrecision (5d, testVectorD.Magnitude ()));

            testVectorD.Normalize ();
            Assert.True (TestUtils.TestPrecision (0.6d, testVectorD.x));
            Assert.True (TestUtils.TestPrecision (0.8d, testVectorD.y));
            Assert.True (TestUtils.TestPrecision (1f, testVectorD.SqrMagnitude ()));
            Assert.True (TestUtils.TestPrecision (1f, testVectorD.Magnitude ()));
        }

        [Fact]
        public void DataTest_Vector2Double_MagnitudePrecision () {
            Vector2Double testVectorD = new (10d, 10d);

            Assert.Equal (200d, testVectorD.SqrMagnitude ());

            testVectorD.Normalize ();
            Assert.True (TestUtils.TestPrecision (1f, testVectorD.SqrMagnitude ()));
            Assert.True (TestUtils.TestPrecision (1f, testVectorD.Magnitude ()));
        }

        [Fact]
        public void DataTest_Vector2Double_BitConvertion () {
            Vector2Double sampleData = new (14.665d, 120.44d);

            byte[] sampleBytes = [.. sampleData.ToByteArray ()];
            int currentByteIndex = 0;
            Vector2Double copyData = new ();
            Assert.True (copyData.NextBytesToParams (sampleBytes, ref currentByteIndex));

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sampleData.GetByteCount (), copyData.GetByteCount ());

            // Excess Read ERROR Detection.
            Vector2Double excessData = new ();
            Assert.False (excessData.NextBytesToParams (sampleBytes, ref currentByteIndex));
        }

        #endregion

    }
}
