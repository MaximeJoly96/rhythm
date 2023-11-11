using Zenyth.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Zenyth.UI
{
    public class DifficultySelectionScreenManager : ScreenManager
    {
        #region Private members
        [SerializeField]
        private Text _difficultyText;
        #endregion

        #region Methods
        public override void Init()
        {
            Hide(true);
            RegisterButtonsEvent();

            gameObject.SetActive(false);
        }

        public override void Fade(bool fadeIn)
        {
            ResetDifficultyButtons();
            ClearDifficultyLabel();
            base.Fade(fadeIn);
        }

        private void RegisterButtonsEvent()
        {
            DifficultyButton[] diffButtons = GetComponentsInChildren<DifficultyButton>();

            for(int i = 0; i < diffButtons.Length; i++)
            {
                DifficultyButton button = diffButtons[i];
                button.DifficultySelectedEvent.AddListener(RaiseDifficultySelectedEvent);
                button.DifficultyHoveredEvent.AddListener(DisplayDifficultyLabel);
                button.HoverExited.AddListener(ClearDifficultyLabel);
            }
        }

        private void RaiseDifficultySelectedEvent(GameManager.Difficulty difficulty)
        {
            GameManager.Instance.SetGameState(GameManager.GameState.SongSelect);
            _ambianceManager.PlayValidation();
        }

        private void ResetDifficultyButtons()
        {
            DifficultyButton[] diffButtons = GetComponentsInChildren<DifficultyButton>();

            for (int i = 0; i < diffButtons.Length; i++)
            {
                diffButtons[i].ResetState();
            }
        }

        private void DisplayDifficultyLabel(GameManager.Difficulty difficulty)
        {
            string label = "";

            switch(difficulty)
            {
                case GameManager.Difficulty.EZ:
                    label = "Easy";
                    break;
                case GameManager.Difficulty.NM:
                    label = "Normal";
                    break;
                case GameManager.Difficulty.HD:
                    label = "Hard";
                    break;
                case GameManager.Difficulty.EX:
                    label = "Expert";
                    break;
                case GameManager.Difficulty.CH:
                    label = "Chaos";
                    break;
            }

            _difficultyText.text = label.ToUpperInvariant();
        }

        private void ClearDifficultyLabel()
        {
            _difficultyText.text = "";
        }
        #endregion
    }
}
