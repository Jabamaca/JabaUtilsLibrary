using UnityEngine;

namespace JabaUtilsLibrary.Unity.Objects {
    public abstract class GlobalSystemObject<T> : MonoBehaviour where T : MonoBehaviour {

        #region Properties

        protected static T _GlobalObject;

        #endregion

        #region Methods

        protected static void RegisterGlobalObject (T globalObject) {

            if (globalObject == null) {
                // ERROR: Can't register null.
                return;
            } else if (_GlobalObject != null) {
                // ERROR: Already registered Global Object, unregister first before registering new.
                return;
            }

            _GlobalObject = globalObject;
        }

        protected static void UnregisterGlobalObject (T globalObject) {
            if (_GlobalObject != globalObject) {
                // ERROR: NOT the registered Global Object.
                return;
            }

            _GlobalObject = null;
        }

        #endregion

    }
}