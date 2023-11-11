using UnityEngine.UI;
using UnityEngine;
using Zenyth.Core;
using System.Collections;

namespace Zenyth.UI.TitleScreen
{
    public class TitleScreenManager : ScreenManager
    {
        #region Private Members
        [SerializeField]
        private Text _title;
        [SerializeField]
        private Text _pressKeyText;

        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private Image _movingBackground;
        [SerializeField]
        private AudioClip _bgm;

        private BackgroundManager _backgroundManager;
        #endregion

        #region Methods
        public override void Init()
        {
            SetBackground();
            SetText("Zenyth", "Press any key to continue");
            _ambianceManager.SetAudio(_bgm);
            _ambianceManager.PlayAudio(0.5f);
        }

        private void SetBackground()
        {
            _backgroundManager = new BackgroundManager(_camera, _movingBackground);
        }

        private void SetText(string title, string pressKeyText)
        {
            _title.text = title.ToUpperInvariant();
            _pressKeyText.text = pressKeyText.ToUpperInvariant();
        }

        private void Update()
        {
            _backgroundManager.MoveBackground();

            if (GameManager.CurrentGameState == GameManager.GameState.HomeScreen)
            {
                if (Input.anyKeyDown)
                {
                    GameManager.SetGameState(GameManager.GameState.DifficultySelect);
                    _ambianceManager.PlayValidation();
                    StartCoroutine(HideTitle());
                }
            }
        }

        private IEnumerator HideTitle()
        {
            float alpha = 0.75f;
            Color newColor = _title.color;
            _pressKeyText.GetComponent<TextFader>().enabled = false;

            while (alpha >= 0.0f)
            {
                newColor.a = Mathf.Lerp(0.0f, 0.75f, alpha);
                alpha -= Time.deltaTime;
                _title.color = newColor;
                _pressKeyText.color = newColor;
                yield return new WaitForEndOfFrame();
            }

            _title.gameObject.SetActive(false);
            _pressKeyText.gameObject.SetActive(false);
        }
        #endregion
    }
}
