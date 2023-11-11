using Zenyth.Core;
using UnityEngine;

namespace Zenyth.UI
{
    public class DifficultySelectionScreenManager : ScreenManager
    {
        #region Methods
        public override void Init()
        {
            Hide(true);
            RegisterButtonsEvent();

            gameObject.SetActive(false);
        }

        private void RegisterButtonsEvent()
        {
            DifficultyButton[] diffButtons = GetComponentsInChildren<DifficultyButton>();

            for(int i = 0; i < diffButtons.Length; i++)
            {
                diffButtons[i].DifficultySelectedEvent.AddListener(RaiseDifficultySelectedEvent);
            }
        }

        private void RaiseDifficultySelectedEvent(GameManager.Difficulty difficulty)
        {
            GameManager.Instance.SetGameState(GameManager.GameState.SongSelect);
            _ambianceManager.PlayValidation();
        }
        #endregion
    }
}
