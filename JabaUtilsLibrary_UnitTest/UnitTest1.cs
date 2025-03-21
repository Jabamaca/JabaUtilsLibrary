using System;
using Xunit;

namespace JabaUtilsLibrary_UnitTest {
    public class UnitTest1 {

        private class CloneTest : ICloneable {
            public int a, b, c;

            public object Clone () {
                return this.MemberwiseClone ();
            }
        }
    }
}