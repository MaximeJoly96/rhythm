using UnityEngine;
using UnityEngine.UI;
using Zenyth.Game;

namespace Zenyth.UI
{
    public class PreGameMenuManager : MonoBehaviour
    {
        [SerializeField]
        private HomeScreenManager _homeScreenManager;
        [SerializeField]
        private DifficultySelectionScreenManager _difficultySelectionScreenManager;
        [SerializeField]
        private SongSelectScreenManager _songSelectScreenManager;

        private GameController _gameController;

        private void Awake()
        {
            _gameController = FindObjectOfType<GameController>();

            _homeScreenManager.Hide(false);
            _difficultySelectionScreenManager.Hide(true);
            _songSelectScreenManager.Hide(true);

            _homeScreenManager.AnyKeyPressedEvent.AddListener(MoveToDifficultySelectionScreen);
        }

        private void MoveToDifficultySelectionScreen()
        {
            _gameController.CurrentGameState = GameController.GameState.DifficultySelect;
            _homeScreenManager.Fade(false);
            _difficultySelectionScreenManager.Fade(true);
        }
    }
}
