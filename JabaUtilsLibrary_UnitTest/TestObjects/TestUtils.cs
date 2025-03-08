namespace JabaUtilsLibrary_UnitTest.TestObjects {
    public static class TestUtils {

        private const double DOUBLE_DIFF_TOLERANCE = 5e-16;

        public static bool TestPrecision (double expected, double result) {
            double diff = result - expected;

            return diff > -DOUBLE_DIFF_TOLERANCE
                && diff < DOUBLE_DIFF_TOLERANCE;
        }

    }
}
