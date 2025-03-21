using JabaUtilsLibrary.Data;
using System.Collections.Generic;
using Xunit;

namespace JabaUtilsLibrary_UnitTest.Tests.Data {
    public class DataTest_Dictionary {

        #region Sample Data

        private readonly Dictionary<string, string> sampleStringDict = new Dictionary<string, string> () {
            { "alpha", "one" },
            { "beta", "two" },
            { "gamma", "three" }, 
            { "delta", "four" }, 
            { "epsilon", "five" },
        };

        private readonly Dictionary<string, string> sampleStringDictWithNull = new Dictionary<string, string> () {
            { "alpha", null },
            { "beta", "two" },
            { "gamma", "three" },
            { "delta", "" },
            { "epsilon", "five" },
        };

        #endregion

        #region Testing Methods

        private static void TestingMethod_ManualDictAdd<K, V> (Dictionary<K, V> fromDict, Dictionary<K, V> toDict) {
            foreach (var kvp in fromDict) {
                toDict.Add (kvp.Key, kvp.Value);
            }
        }

        #endregion

        #region Main Tests

        [Fact]
        public void DataTest_Dictionary_CheckStrictEquals_Different () {
            Assert.False (DictionaryUtils.CheckStrictEquals (sampleStringDict, sampleStringDictWithNull));
        }

        [Fact]
        public void DataTest_Dictionary_CheckStrictEquals_Full () {
            Dictionary<string, string> sampleDict1 = new Dictionary<string, string> ();
            Dictionary<string, string> sampleDict2 = new Dictionary<string, string> ();
            TestingMethod_ManualDictAdd (sampleStringDict, sampleDict1);
            TestingMethod_ManualDictAdd (sampleStringDict, sampleDict2);

            Assert.True (DictionaryUtils.CheckStrictEquals (sampleDict1, sampleDict2));

            // Manual remove.
            sampleDict1.Remove ("alpha");

            Assert.False (DictionaryUtils.CheckStrictEquals (sampleDict1, sampleDict2));
        }

        [Fact]
        public void DataTest_Dictionary_CheckStrictEquals_WithNull () {
            Dictionary<string, string> sampleDict1 = new Dictionary<string, string> ();
            Dictionary<string, string> sampleDict2 = new Dictionary<string, string> ();
            TestingMethod_ManualDictAdd (sampleStringDict, sampleDict1);
            TestingMethod_ManualDictAdd (sampleStringDict, sampleDict2);

            Assert.True (DictionaryUtils.CheckStrictEquals (sampleDict1, sampleDict2));

            // Manual null set.
            sampleDict1["beta"] = null;
            Assert.False (DictionaryUtils.CheckStrictEquals (sampleDict1, sampleDict2));

            // Manual remove.
            sampleDict1.Remove ("gamma");
            sampleDict2.Remove ("epsilon");

            Assert.False (DictionaryUtils.CheckStrictEquals (sampleDict1, sampleDict2));
        }

        [Fact]
        public void DataTest_Dictionary_CheckNonStrictEquals_Full () {
            Dictionary<string, string> sampleDict1 = new Dictionary<string, string> ();
            Dictionary<string, string> sampleDict2 = new Dictionary<string, string> ();
            TestingMethod_ManualDictAdd (sampleStringDict, sampleDict1);
            TestingMethod_ManualDictAdd (sampleStringDict, sampleDict2);

            Assert.True (DictionaryUtils.CheckNonStrictEquals (sampleDict1, sampleDict2));

            // Manual remove.
            sampleDict1.Remove ("alpha");

            Assert.False (DictionaryUtils.CheckNonStrictEquals (sampleDict1, sampleDict2));
            Assert.False (DictionaryUtils.CheckNonStrictEquals (sampleDict2, sampleDict1));
        }

        [Fact]
        public void DataTest_Dictionary_CheckNonStrictEquals_RemoveAndSet () {
            Dictionary<string, string> sampleDict1 = new Dictionary<string, string> ();
            Dictionary<string, string> sampleDict2 = new Dictionary<string, string> ();
            TestingMethod_ManualDictAdd (sampleStringDict, sampleDict1);
            TestingMethod_ManualDictAdd (sampleStringDict, sampleDict2);

            Assert.True (DictionaryUtils.CheckNonStrictEquals (sampleDict1, sampleDict2));

            // Manual remove and set.
            sampleDict1.Remove ("alpha");
            sampleDict2["alpha"] = null;

            Assert.True (DictionaryUtils.CheckNonStrictEquals (sampleDict1, sampleDict2));

            // Manual re-add.
            sampleDict1["alpha"] = "imaginary";

            Assert.False (DictionaryUtils.CheckNonStrictEquals (sampleDict1, sampleDict2));
        }

        [Fact]
        public void DataTest_Dictionary_CheckNonStrictEquals_Excess () {
            Dictionary<string, string> sampleDict1 = new Dictionary<string, string> ();
            Dictionary<string, string> sampleDict2 = new Dictionary<string, string> ();
            TestingMethod_ManualDictAdd (sampleStringDict, sampleDict1);
            TestingMethod_ManualDictAdd (sampleStringDict, sampleDict2);

            Assert.True (DictionaryUtils.CheckNonStrictEquals (sampleDict1, sampleDict2));

            // Manual remove and set.
            sampleDict2["zeta"] = null;
            sampleDict2["eta"] = null;
            sampleDict2["theta"] = null;
            sampleDict2["iota"] = null;

            Assert.True (DictionaryUtils.CheckNonStrictEquals (sampleDict2, sampleDict1));

            sampleDict1["kappa"] = null;
            sampleDict1["lambda"] = null;

            Assert.True (DictionaryUtils.CheckNonStrictEquals (sampleDict2, sampleDict1));

            sampleDict1["lambda"] = "Euler's Number";

            Assert.False (DictionaryUtils.CheckNonStrictEquals (sampleDict1, sampleDict2));
            Assert.False (DictionaryUtils.CheckNonStrictEquals (sampleDict2, sampleDict1));
        }

        #endregion

    }
}
