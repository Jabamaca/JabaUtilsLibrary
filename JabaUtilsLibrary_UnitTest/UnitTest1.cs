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