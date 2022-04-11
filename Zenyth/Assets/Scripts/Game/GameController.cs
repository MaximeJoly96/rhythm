using UnityEngine;
using Zenyth.Models;

namespace Zenyth.Game
{
    public class GameController : MonoBehaviour
    {
        public enum GameState { HomeScreen, DifficultySelect, SongSelect, InGame }

        public GameState CurrentGameState { get; set; }
        public Song CurrentlySelectedSong { get; set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

