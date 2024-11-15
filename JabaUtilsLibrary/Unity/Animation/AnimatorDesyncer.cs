using UnityEngine;

namespace JabaUtilsLibrary.Unity.Animation {
    public class AnimatorDesyncer : MonoBehaviour {

        #region Properties

        private const int ALL_LAYERS = 0;

        [SerializeField]
        private Animator _animator = null;
        [SerializeField]
        private int _maxFrameOffset = 0;
        [SerializeField]
        private string _stateName = "";

        #endregion

        #region Unity Internal Methods

        private void Start () {
            DesyncAnimation ();
        }

        #endregion

        #region Methods

        private void DesyncAnimation () {
            int randOffset = Random.Range (0, _maxFrameOffset);
            _animator.Play (_stateName, ALL_LAYERS, randOffset);
        }

        #endregion

    }
}