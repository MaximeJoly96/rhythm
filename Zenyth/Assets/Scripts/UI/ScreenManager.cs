using UnityEngine;
using Zenyth.Game;
using System.Collections;

namespace Zenyth.UI
{
    public abstract class ScreenManager : MonoBehaviour
    {
        private const float FADE_STEP = 0.025f;

        protected GameController _gameController;
        protected CanvasGroup _canvasGroup;

        protected GameController GameController
        {
            get
            {
                if (_gameController == null)
                    _gameController = FindObjectOfType<GameController>();

                return _gameController;
            }
        }
        protected CanvasGroup CanvasGroup
        {
            get
            {
                if (_canvasGroup == null)
                    _canvasGroup = GetComponent<CanvasGroup>();

                return _canvasGroup;
            }
        }

        public void Fade(bool fadeIn)
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
    }
}
