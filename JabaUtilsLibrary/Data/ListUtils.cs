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

            List<T> list2Copy = new List<T> (list2);

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
            List<T> shuffledList = new List<T> ();
            List<T> randomPool = new List<T> ();
            randomPool.AddRange (list);

            int itemCount = randomPool.Count;
            for (int j = 0; j < itemCount; j++) {
                int randIndex = randomizer.Next () % randomPool.Count;
                shuffledList.Add (randomPool[randIndex]);
                randomPool.RemoveAt (randIndex);
            }

            return shuffledList;
        }

        public static void InsertAt<T> (T entry, List<T> list, int index) {
            int nextFinalIndex = list.Count;

            if (nextFinalIndex <= 0) {
                list.Add (entry); // List is empty. Just add entry.
                return;
            } else if (index < 0) {
                index = 0; // Index less than the valid. Correct to 0.
            } else if (index > nextFinalIndex) {
                index = nextFinalIndex; // Index more than the valid. Correct to the next final index.
            }

            list.Add (entry); // Add to make additional capacity.

            T currentEntry = entry, entryBuffer = entry;

            for (int i = index; i <= nextFinalIndex; i++) {
                entryBuffer = list[i];
                list[i] = currentEntry;
                currentEntry = entryBuffer;
            }
        }

        #endregion

    }

}