namespace JabaUtilsLibrary_UnitTest.TestObjects {
    public class EqualObjectSample {

        #region Properties

        public int intParam1;
        public int intParam2;
        public string stringParam;

        #endregion

        #region Constructors

        public EqualObjectSample (int intParam1, int intParam2, string stringParam) {
            this.intParam1 = intParam1;
            this.intParam2 = intParam2;
            this.stringParam = stringParam;
        }

        #endregion

        #region Methods

        #endregion

        #region Internal Methods

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public override bool Equals (object obj) {
            if (!(obj is EqualObjectSample other))
                return false;

            return this.intParam1.Equals (other.intParam1)
                && this.intParam2.Equals (other.intParam2)
                && this.stringParam.Equals (other.stringParam);
        }

        #endregion

    }
}
