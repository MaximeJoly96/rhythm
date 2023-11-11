using UnityEngine;
using Zenyth.UI.TitleScreen;

namespace Zenyth.UI
{
    public class UiManager : MonoBehaviour
    {
        #region Private Members
        [SerializeField]
        private TitleScreenManager _titleScreenManager;
        [SerializeField]
        private DifficultySelectionScreenManager _diffSelectionScreenManager;
        [SerializeField]
        private SongSelectScreenManager _songSelectScreenManager;
        #endregion

        #region Methods
        public void Init()
        {
            _titleScreenManager.Init();
            _diffSelectionScreenManager.Init();
            _songSelectScreenManager.Init();
        }

        public void DisplayDifficultySelectionScreen()
        {
            DisplayScreenManager(_diffSelectionScreenManager, true);
        }

        public void HideDifficultySelectionScreen()
        {
            DisplayScreenManager(_diffSelectionScreenManager, false);
        }

        public void ShowSongSelectScreen()
        {
            DisplayScreenManager(_songSelectScreenManager, true);
        }

        private void DisplayScreenManager(ScreenManager manager, bool display)
        {
            manager.gameObject.SetActive(display);
            if(display)
                manager.Fade(display);
        }
        #endregion
    }
}
