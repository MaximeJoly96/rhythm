using UnityEngine;
using UnityEngine.Events;
using Zenyth.UI;
using UnityEngine.SceneManagement;

namespace Zenyth.Core
{
    public class GameManager : MonoBehaviour
    {
        #region Enums
        public enum GameState { HomeScreen, DifficultySelect, SongSelect, InGame }
        public enum Difficulty { EZ, NM, HD, EX, CH }
        #endregion

        #region Private members
        [Header("Managers")]
        [SerializeField]
        private UiManager _uiManager;
        #endregion

        #region Properties
        public GameState CurrentGameState { get; private set; }
        public static GameManager Instance { get; private set; }
        #endregion

        #region Events
        public UnityEvent<GameState> GameStateChangedEvent { get; private set; }
        #endregion

        #region Methods
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            GameStateChangedEvent = new UnityEvent<GameState>();
            GameStateChangedEvent.AddListener(CheckForGameState);
            SetGameState(GameState.HomeScreen);
        }

        private void Start()
        {
            _uiManager.Init();
        }

        public void SetGameState(GameState state)
        {
            CurrentGameState = state;
            GameStateChangedEvent.Invoke(CurrentGameState);
        }

        public void BackButtonClicked()
        {
            CurrentGameState--;
            SetGameState(CurrentGameState);
        }

        private void CheckForGameState(GameState state)
        {
            switch(state)
            {
                case GameState.HomeScreen:
                    break;
                case GameState.DifficultySelect:
                    _uiManager.HideSongSelectScreen();
                    _uiManager.DisplayDifficultySelectionScreen();
                    break;
                case GameState.SongSelect:
                    _uiManager.HideDifficultySelectionScreen();
                    _uiManager.DisplaySongSelectScreen();
                    break;
                case GameState.InGame:
                    break;
            }
        }

        public void LoadRewards()
        {
            SceneManager.LoadScene("Rewards");
        }
        #endregion
    }
}
