using UnityEngine;
using System.Collections.Generic;
using Zenyth.FileReading;
using Zenyth.Models;

namespace Zenyth.Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private MusicPlayer _musicPlayer;
        [SerializeField]
        private PatternManager _patternManager;

        private List<TimeStamp> _timeStamps;
        private int _stampIndex = 0;
        private float _timer = 0.0f;

        private void Awake()
        {
            Application.targetFrameRate = 144;
            _timeStamps = SongDataReader.ReadTimeStampsForSong(_musicPlayer.Song);
            //BeatmapConverter.ConvertBeatmap("E:\\LavenderTown.osu");
        }

        private void Start()
        {
            _musicPlayer.PlayMusic();
        }
    }
}

