using System.Collections.Generic;

namespace JabaUtilsLibrary.Data {
    public class ArrayUtils {

        #region Methods

        public static bool CheckOrderedEquals<T> (T[] list1, T[] list2) {
            // Check list content count.
            if (list1.Length != list2.Length)
                return false;

            int itemCount = list1.Length;
            for (int i = 0; i < itemCount; i++) {
                T item1 = list1[i];
                T item2 = list2[i];

                // Check NULL equality.
                if (item1 == null && item2 == null)
                    continue;
                else if (item1 == null || item2 == null)
                    return false;

                // Check equality of same indexes.
                if (!item1.Equals (item2))
                    return false;
            }

            return true;
        }

        #endregion

    }
}
