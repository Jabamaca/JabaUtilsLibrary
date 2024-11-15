using System.Collections.Generic;
using System;

namespace JabaUtilsLibrary.Data {

    public class ShufflingList<T> {

        #region Properties

        private readonly List<T> _itemList = [];
        private readonly List<T> _randomPool = [];
        private readonly List<T> _shuffledList = [];
        private readonly Random _randomizer = null;

        public IReadOnlyList<T> ShuffledList => _shuffledList;

        #endregion

        #region Constructors

        public ShufflingList (IEnumerable<T> initList, Random randomizer) {
            _randomizer = randomizer;
            SetNewItemList (initList, true);
        }

        #endregion

        #region Methods

        public void SetNewItemList (IEnumerable<T> newList, bool shuffle) {
            _itemList.Clear ();
            AddItemsToList (newList, shuffle);
        }

        public void AddItemToList (T item, bool shuffle) {
            _itemList.Add (item);

            if (shuffle) {
                Shuffle ();
            } else {
                _shuffledList.Add (item);
            }
        }

        public void AddItemsToList (IEnumerable<T> items, bool shuffle) {
            _itemList.AddRange (items);

            if (shuffle) {
                Shuffle ();
            } else {
                _shuffledList.AddRange (items);
            }
        }

        public void Shuffle () {
            _randomPool.Clear ();
            _randomPool.AddRange (_itemList);
            _shuffledList.Clear ();

            int itemCount = _randomPool.Count;
            for (int j = 0; j < itemCount; j++) {
                int randIndex = _randomizer.Next (0, _randomPool.Count);
                _shuffledList.Add (_randomPool[randIndex]);
                _randomPool.RemoveAt (randIndex);
            }
        }

        #endregion

    }

}