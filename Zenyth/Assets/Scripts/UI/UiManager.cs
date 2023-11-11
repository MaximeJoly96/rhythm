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
        [SerializeField]
        private BackButtonManager _backButtonManager;
        #endregion

        #region Methods
        public void Init()
        {
            _titleScreenManager.Init();
            _diffSelectionScreenManager.Init();
            _songSelectScreenManager.Init();
            _backButtonManager.Init();
        }

        public void DisplayDifficultySelectionScreen()
        {
            DisplayScreenManager(_diffSelectionScreenManager, true);
        }

        public void HideDifficultySelectionScreen()
        {
            DisplayScreenManager(_diffSelectionScreenManager, false);
        }

        public void DisplaySongSelectScreen()
        {
            DisplayScreenManager(_songSelectScreenManager, true);
            DisplayScreenManager(_backButtonManager, true);
        }

        public void HideSongSelectScreen()
        {
            DisplayScreenManager(_songSelectScreenManager, false);
            DisplayScreenManager(_backButtonManager, false);
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
