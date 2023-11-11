using UnityEngine;
using System.Collections;
using Zenyth.Core;

namespace Zenyth.UI
{
    public abstract class ScreenManager : MonoBehaviour
    {
        #region Constants
        private const float FADE_STEP = 0.025f;
        #endregion

        #region Protected members
        protected CanvasGroup _canvasGroup;
        protected GameManager _gameManager;

        [SerializeField]
        protected AmbianceManager _ambianceManager;
        #endregion

        #region Properties
        protected CanvasGroup CanvasGroup
        {
            get
            {
                if (_canvasGroup == null)
                    _canvasGroup = GetComponent<CanvasGroup>();

                return _canvasGroup;
            }
        }

        protected GameManager GameManager
        {
            get
            {
                if (_gameManager == null)
                    _gameManager = GameManager.Instance;

                return _gameManager;
            }
        }
        #endregion

        #region Methods
        public abstract void Init();
        public virtual void Fade(bool fadeIn)
        {
            StartCoroutine(fadeIn ? FadeIn() : FadeOut());
        }

        public virtual void Hide(bool hide)
        {
            CanvasGroup.alpha = hide ? 0.0f : 1.0f;
        }

        protected IEnumerator FadeIn()
        {
            for(float a = 0.0f; a < 1.0f; a += FADE_STEP)
            {
                CanvasGroup.alpha = a;
                yield return null;
            }

            CanvasGroup.alpha = 1.0f;
        }

        protected IEnumerator FadeOut()
        {
            for (float a = 1.0f; a > 0.0f; a -= FADE_STEP)
            {
                CanvasGroup.alpha = a;
                yield return null;
            }

            CanvasGroup.alpha = 0.0f;
        }
        #endregion
    }
}
