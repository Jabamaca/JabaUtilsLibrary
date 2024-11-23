namespace JabaUtilsLibrary_UnitTest.TestObjects {
    public class EqualObjectSample (int intParam1, int intParam2, string stringParam) {

        #region Properties

        public int intParam1 = intParam1;
        public int intParam2 = intParam2;
        public string stringParam = stringParam;

        #endregion
        #region Constructors

        #endregion

        #region Methods

        #endregion

        #region Internal Methods

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public override bool Equals (object obj) {
            if (obj is not EqualObjectSample other)
                return false;

            return this.intParam1.Equals (other.intParam1)
                && this.intParam2.Equals (other.intParam2)
                && this.stringParam.Equals (other.stringParam);
        }

        #endregion

    }
}
