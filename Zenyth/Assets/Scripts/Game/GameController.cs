using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private MusicPlayer _musicPlayer;
    [SerializeField]
    private GameObject _projectile;

    private List<float> _timeStamps;
    private int _stampIndex = 0;
    private float _timer = 0.0f;

    private void Awake()
    {
        Application.targetFrameRate = 144;
        _timeStamps = SongDataReader.ReadTimeStampsForSong(_musicPlayer.Song);
        //BeatmapConverter.ConvertBeatmap("C:\\Users\\Maxah\\Desktop\\Nekomata Master feat. Shimotsuki Haruka - Element of SPADA (Frey) [Another].osu");
    }

    private void Start()
    {
        _musicPlayer.PlayMusic();
    }

    private void Update()
    {
        if(_stampIndex < _timeStamps.Count && _timer >= _timeStamps[_stampIndex])
        {
            Debug.Log(_timer + " " + _timeStamps[_stampIndex]);
            Instantiate(_projectile);
            _stampIndex++;
        }

        _timer += Time.deltaTime;
    }
}
