using JabaUtilsLibrary.Data.DataStructs;
using JabaUtilsLibrary_UnitTest.TestObjects;
using Xunit;

namespace JabaUtilsLibrary_UnitTest.Tests.Data {
    public class DataTest_Vector {

        #region Test Methods

        #endregion

        #region Main Tests

        [Fact]
        public void DataTest_Vector2Double_Magnitude () {
            Vector2Double testVectorD = new Vector2Double (3d, 4d);

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
            Vector2Double testVectorD = new Vector2Double (10d, 10d);

            Assert.Equal (200d, testVectorD.SqrMagnitude ());

            testVectorD.Normalize ();
            Assert.True (TestUtils.TestPrecision (1f, testVectorD.SqrMagnitude ()));
            Assert.True (TestUtils.TestPrecision (1f, testVectorD.Magnitude ()));
        }

        [Fact]
        public void DataTest_Vector2Double_BitConvertion () {
            Vector2Double sampleData = new Vector2Double (14.665d, 120.44d);

            byte[] sampleBytes = sampleData.ToByteArray ();
            int currentByteIndex = 0;
            Vector2Double copyData = new Vector2Double ();
            Assert.True (copyData.NextBytesToParams (sampleBytes, ref currentByteIndex));

            Assert.True (copyData.Equals (sampleData));
            Assert.Equal (sampleData.GetByteCount (), copyData.GetByteCount ());

            // Excess Read ERROR Detection.
            Vector2Double excessData = new Vector2Double ();
            Assert.False (excessData.NextBytesToParams (sampleBytes, ref currentByteIndex));
        }

        #endregion

    }
}
