using JabaUtilsLibrary.Data;
using System.Collections.Generic;

namespace JabaUtilsLibrary_UnitTest.Tests.Data {
    public class DataTest_Dictionary {

        #region Sample Data

        private readonly Dictionary<string, string> sampleStringDict = new () {
            { "alpha", "one" },
            { "beta", "two" },
            { "gamma", "three" }, 
            { "delta", "four" }, 
            { "epsilon", "five" },
        };

        private readonly Dictionary<string, string> sampleStringDictWithNull = new () {
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
        public void DataTest_Dictionary_CheckEquals_Different () {
            Assert.False (DictionaryUtils.CheckEquals (sampleStringDict, sampleStringDictWithNull));
        }

        [Fact]
        public void DataTest_Dictionary_CheckEquals_Full () {
            Dictionary<string, string> sampleDict1 = [];
            Dictionary<string, string> sampleDict2 = [];
            TestingMethod_ManualDictAdd (sampleStringDict, sampleDict1);
            TestingMethod_ManualDictAdd (sampleStringDict, sampleDict2);

            Assert.True (DictionaryUtils.CheckEquals (sampleDict1, sampleDict2));

            // Manual remove.
            sampleDict1.Remove ("alpha");

            Assert.False (DictionaryUtils.CheckEquals (sampleDict1, sampleDict2));
        }

        [Fact]
        public void DataTest_Dictionary_CheckEquals_WithNull () {
            Dictionary<string, string> sampleDict1 = [];
            Dictionary<string, string> sampleDict2 = [];
            TestingMethod_ManualDictAdd (sampleStringDict, sampleDict1);
            TestingMethod_ManualDictAdd (sampleStringDict, sampleDict2);

            Assert.True (DictionaryUtils.CheckEquals (sampleDict1, sampleDict2));

            // Manual null set.
            sampleDict1["beta"] = null;
            Assert.False (DictionaryUtils.CheckEquals (sampleDict1, sampleDict2));

            // Manual remove.
            sampleDict1.Remove ("gamma");
            sampleDict2.Remove ("epsilon");

            Assert.False (DictionaryUtils.CheckEquals (sampleDict1, sampleDict2));
        }

        #endregion

    }
}
