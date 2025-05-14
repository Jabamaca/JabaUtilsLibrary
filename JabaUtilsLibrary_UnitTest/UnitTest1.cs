using JabaUtilsLibrary.Data.DataStructs;
using System;
using System.Collections.Generic;
using Xunit;

namespace JabaUtilsLibrary_UnitTest {
    public class UnitTest1 {

        private abstract class A {

            public abstract void Test1 ();
            public abstract void Test2 ();

        }

        private abstract class AA : A {

            public override void Test1 () {
                Console.WriteLine ("1 AA");
            }

            public override void Test2 () {
                Test1 ();
                Console.WriteLine ("2 AA");
            }

        }

        private class AAA : AA {

            public override void Test1 () {
                Console.WriteLine ("1 AAA");
            }

            public override void Test2 () {
                base.Test2 ();
                base.Test1 ();
                Test1 ();
                Console.WriteLine ("2 AAA");
            }

        }

        [Fact]
        public void Experiment_StructInequality () {
            Vector2Int vecBase = new Vector2Int (2, 2);
            Vector2Int vec1 = vecBase, vec2 = vecBase;
            Assert.Equal (vec1, vec2);
            vec2 += new Vector2Int (3, 3);
            Assert.NotEqual (vec2, vec1);
            Assert.NotEqual (vec2, vecBase);
            Assert.Equal (vec1, vecBase);

        }

        [Fact]
        public void Experiment_OverrideEqualsAsKey () {
            Dictionary<Vector2Int, int> testDict = new Dictionary<Vector2Int, int> ();
            Vector2Int key1 = new Vector2Int (2, 2), key2 = key1.Copy ();
            int value1 = 3, value2 = 89;

            testDict[key1] = value1;
            testDict[key2] = value2;

            Assert.Equal (testDict[key1], testDict[key2]);
            Assert.Equal (testDict[key1], value2);
        }

        [Fact]
        public void Experiment_Override () {
            AAA testInstance = new AAA ();
            List<AA> testList = new List<AA> {
                testInstance
            };

            testInstance.Test2 ();
            foreach (var testMember in testList) {
                testMember.Test1 ();
                testMember.Test2 ();
            }
        }

    }
}