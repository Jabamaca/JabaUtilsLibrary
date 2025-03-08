using System;

namespace JabaUtilsLibrary_UnitTest {
    public class UnitTest1 {

        private class CloneTest : ICloneable {
            public int a, b, c;

            public object Clone () {
                return this.MemberwiseClone ();
            }
        }

        [Fact]
        public void ExperimentalTesting () {
            var testA = new CloneTest {
                a = 1,
                b = 2,
                c = 3,
            };

            var testB = (CloneTest)testA.Clone ();

            Assert.Equal (testA.a, testB.a);
            Assert.Equal (testA.b, testB.b);
            Assert.Equal (testA.c, testB.c);

            testB.a = 69;
            Assert.NotEqual (testA.a, testB.a);
        }

    }
}