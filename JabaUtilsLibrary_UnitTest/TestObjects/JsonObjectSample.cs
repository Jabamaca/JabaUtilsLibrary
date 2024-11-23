using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JabaUtilsLibrary_UnitTest.TestObjects {
    internal class JsonObjectSample {

        #region Properties

        public int IntParam {
            set; get;
        }

        public double DoubleParam {
            set; get;
        }

        public float FloatParam {
            set; get;
        }

        public string StringParam {
            set; get;
        }

        #endregion

        #region Internal Methods

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public override bool Equals (object obj) {
            if (obj is not JsonObjectSample other)
                return false;

            return this.IntParam.Equals (other.IntParam)
                && this.DoubleParam.Equals (other.DoubleParam)
                && this.FloatParam.Equals (other.FloatParam)
                && this.StringParam.Equals (other.StringParam);
        }

        #endregion

    }
}
