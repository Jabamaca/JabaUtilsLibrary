using System;
using System.Collections.Generic;

namespace JabaUtilsLibrary.Data {

    public static class ListUtils {

        #region Methods

        public static bool CheckOrderedEquals<T> (List<T> list1, List<T> list2) {
            // Check list content count.
            if (list1.Count != list2.Count)
                return false;

            int itemCount = list1.Count;
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

        public static bool CheckUnorderedEquals<T> (List<T> list1, List<T> list2) {
            // Check list content count.
            if (list1.Count != list2.Count)
                return false;

            List<T> list2Copy = new (list2);

            foreach (var item1 in list1) {
                var itemCopy = item1;
                bool isMissingItem = true;
                foreach (var item2 in list2Copy) {
                    if ((item1 == null && item2 == null) 
                        || item1.Equals (item2)) {
                        itemCopy = item2;
                        isMissingItem = false;
                        break;
                    }
                }

                if (isMissingItem) {
                    return false;
                } else {
                    list2Copy.Remove (itemCopy);
                }
            }

            return true;
        }

        public static List<T> ShuffleList<T> (List<T> list, Random randomizer) {
            List<T> shuffledList = [];
            List<T> randomPool = [.. list];

            int itemCount = randomPool.Count;
            for (int j = 0; j < itemCount; j++) {
                int randIndex = randomizer.Next () % randomPool.Count;
                shuffledList.Add (randomPool[randIndex]);
                randomPool.RemoveAt (randIndex);
            }

            return shuffledList;
        }

        #endregion

    }

}