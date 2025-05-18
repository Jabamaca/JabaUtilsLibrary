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

        private static void TestMethod_InsertToEmpty (int index) {
            List<string> sampleStringList = new List<string> ();
            string sampleString = "mate";
            List<string> expectedResultList = new List<string> {
                sampleString,
            };

            ListUtils.InsertAt (sampleString, sampleStringList, index);

            Assert.True (ListUtils.CheckOrderedEquals (expectedResultList, sampleStringList));
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

        [Fact]
        public void DataTest_List_InsertToEmpty_IndexZero () {
            TestMethod_InsertToEmpty (index: 0);
        }

        [Fact]
        public void DataTest_List_InsertToEmpty_IndexNegative () {
            TestMethod_InsertToEmpty (index: -20);
        }

        [Fact]
        public void DataTest_List_InsertToEmpty_IndexExcess () {
            TestMethod_InsertToEmpty (index: 3);
        }

        [Fact]
        public void DataTest_List_InsertToFilled_IndexZero () {
            List<string> sampleList = new List<string> {
                "one", "two", "three", "four",
            };
            string sampleEntry = "x_point_five";
            List<string> expectedResultList = new List<string> {
                sampleEntry, sampleList[0], sampleList[1], sampleList[2], sampleList[3],
            };

            ListUtils.InsertAt (sampleEntry, sampleList, 0);
            Assert.True (ListUtils.CheckOrderedEquals (expectedResultList, sampleList));
        }

        [Fact]
        public void DataTest_List_InsertToFilled_IndexNegative () {
            List<string> sampleList = new List<string> {
                "one", "two", "three", "four",
            };
            string sampleEntry = "x_point_five";
            List<string> expectedResultList = new List<string> {
                sampleEntry, sampleList[0], sampleList[1], sampleList[2], sampleList[3],
            };

            ListUtils.InsertAt (sampleEntry, sampleList, -1502);
            Assert.True (ListUtils.CheckOrderedEquals (expectedResultList, sampleList));
        }

        [Fact]
        public void DataTest_List_InsertToFilled_IndexValid () {
            List<string> sampleList = new List<string> {
                "one", "two", "three", "four",
            };
            string sampleEntry = "x_point_five";
            List<string> expectedResultList = new List<string> {
                sampleList[0], sampleList[1], sampleEntry, sampleList[2], sampleList[3],
            };

            ListUtils.InsertAt (sampleEntry, sampleList, 2);
            Assert.True (ListUtils.CheckOrderedEquals (expectedResultList, sampleList));
        }

        [Fact]
        public void DataTest_List_InsertToFilled_IndexCount () {
            List<string> sampleList = new List<string> {
                "one", "two", "three", "four",
            };
            string sampleEntry = "x_point_five";
            List<string> expectedResultList = new List<string> {
                sampleList[0], sampleList[1], sampleList[2], sampleList[3], sampleEntry,
            };

            ListUtils.InsertAt (sampleEntry, sampleList, 4);
            Assert.True (ListUtils.CheckOrderedEquals (expectedResultList, sampleList));
        }

        [Fact]
        public void DataTest_List_InsertToFilled_IndexExcess () {
            List<string> sampleList = new List<string> {
                "one", "two", "three", "four",
            };
            string sampleEntry = "x_point_five";
            List<string> expectedResultList = new List<string> {
                sampleList[0], sampleList[1], sampleList[2], sampleList[3], sampleEntry,
            };

            ListUtils.InsertAt (sampleEntry, sampleList, 9148);
            Assert.True (ListUtils.CheckOrderedEquals (expectedResultList, sampleList));
        }

        #endregion

    }
}