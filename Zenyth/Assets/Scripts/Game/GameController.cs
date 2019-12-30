using UnityEngine;
using System.Collections.Generic;
using Zenyth.FileReading;
using Zenyth.Tools;
using Zenyth.Models;

namespace Zenyth.Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private MusicPlayer _musicPlayer;

        private ProjectilePool _projectilePool;

        private List<TimeStamp> _timeStamps;
        private int _stampIndex = 0;
        private float _timer = 0.0f;

        public ProjectilePool ProjectilePool
        {
            get { return _projectilePool; }
        }

        private void Awake()
        {
            Application.targetFrameRate = 144;
            _timeStamps = SongDataReader.ReadTimeStampsForSong(_musicPlayer.Song);
            _projectilePool = new ProjectilePool();
            //BeatmapConverter.ConvertBeatmap("C:\\Users\\Maxah\\Desktop\\Nekomata Master feat. Shimotsuki Haruka - Element of SPADA (Frey) [Another].osu");
        }

        private void Start()
        {
            _musicPlayer.PlayMusic();
        }

        private void Update()
        {
            if (_stampIndex < _timeStamps.Count && _timer >= _timeStamps[_stampIndex].Time)
            {
                ProjectilesPattern pattern = GameObject.Find("Pattern_" + _timeStamps[_stampIndex].Pattern).GetComponent<ProjectilesPattern>();
                foreach(Projectile proj in pattern.Projectiles)
                {
                    ProjectileBehaviour beh = _projectilePool.GetObject();
                    beh.Projectile = proj;
                }
                
                _stampIndex++;
            }

            _timer += Time.deltaTime;
        }
    }
}

