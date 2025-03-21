using System;
using System.Collections.Generic;
using JabaUtilsLibrary.Data;
using Xunit;

namespace JabaUtilsLibrary_UnitTest.Tests.Data {
    public class DataTest_List {

        #region Sample Data

        private readonly List<string> sampleStringList = new List<string> { "alpha", "beta", "gamma", "delta", "epsilon" };
        private readonly List<string> sampleStringListWithNull = new List<string> { "alpha", null, null, "delta", null, "zeta" };

        #endregion

        #region Testing Methods

        private static void TestMethod_CheckOrderedEquals<T> (List<T> sampleList) {
            List<T> sampleList1 = new List<T> ();
            sampleList1.AddRange (sampleList);
            List<T> sampleList2 = new List<T> ();
            sampleList2.AddRange (sampleList);

            Assert.True (ListUtils.CheckOrderedEquals (sampleList1, sampleList2));

            // Manual shuffle.
            (sampleList2[1], sampleList2[0]) = (sampleList2[0], sampleList2[1]);
            (sampleList2[4], sampleList2[3]) = (sampleList2[3], sampleList2[4]);

            Assert.False (ListUtils.CheckOrderedEquals (sampleList1, sampleList2));
        }

        private static void TestMethod_CheckUnorderedEquals<T> (List<T> sampleList) {
            List<T> sampleList1 = new List<T> ();
            sampleList1.AddRange (sampleList);
            List<T> sampleList2 = new List<T> ();
            sampleList2.AddRange (sampleList);

            Assert.True (ListUtils.CheckUnorderedEquals (sampleList1, sampleList2));

            // Manual shuffle.
            (sampleList2[1], sampleList2[0]) = (sampleList2[0], sampleList2[1]);
            (sampleList2[4], sampleList2[3]) = (sampleList2[3], sampleList2[4]);

            Assert.True (ListUtils.CheckUnorderedEquals (sampleList1, sampleList2));
        }

        #endregion

        #region Main Tests

        [Fact]
        public void DataTest_List_CheckEquals_Different () {
            Assert.False (ListUtils.CheckOrderedEquals (sampleStringList, sampleStringListWithNull));
            Assert.False (ListUtils.CheckUnorderedEquals (sampleStringList, sampleStringListWithNull));
        }

        [Fact]
        public void DataTest_List_CheckOrderedEquals_Full () {
            TestMethod_CheckOrderedEquals (sampleStringList);
        }

        [Fact]
        public void DataTest_List_CheckOrderedEquals_WithNull () {
            TestMethod_CheckOrderedEquals (sampleStringListWithNull);
        }

        [Fact]
        public void DataTest_List_CheckUnorderedEquals_Full () {
            TestMethod_CheckUnorderedEquals (sampleStringList);
        }

        [Fact]
        public void DataTest_List_CheckUnorderedEquals_WithNull () {
            TestMethod_CheckUnorderedEquals (sampleStringListWithNull);
        }

        [Fact]
        public void DataTest_List_ShuffleList () {
            List<string> sampleStringList1 = new List<string> ();
            sampleStringList1.AddRange (sampleStringList);
            // Shuffle by ShuffleList method.
            List<string> sampleStringList2 = ListUtils.ShuffleList (sampleStringList1, new Random (Seed: 45678));

            Assert.True (ListUtils.CheckUnorderedEquals (sampleStringList1, sampleStringList2));
        }

        #endregion

    }
}