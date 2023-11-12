using UnityEngine;
using Zenyth.Core;

namespace Zenyth.Game
{
    public class Conductor : MonoBehaviour
    {
        //Song beats per minute
        //This is determined by the song you're trying to sync up to
        [SerializeField]
        private float _songBpm;

        //The number of seconds for each song beat
        [SerializeField]
        private float _secPerBeat;

        //Current song position, in seconds
        [SerializeField]
        private float _songPosition;

        //Current song position, in beats
        [SerializeField]
        private float _songPositionInBeats;

        //How many seconds have passed since the song started
        [SerializeField]
        private float _dspSongTime;

        //an AudioSource attached to this GameObject that will play the music.
        [SerializeField]
        private AudioSource _musicSource;

        //The current relative position of the song within the loop measured between 0 and 1.
        [SerializeField]
        private float _loopPositionInAnalog;

        //the number of beats in each loop
        [SerializeField]
        private float _beatsPerLoop;

        //the total number of loops completed since the looping clip first started
        [SerializeField]
        private int _completedLoops = 0;

        //The current position of the song within the loop in beats.
        [SerializeField]
        private float _loopPositionInBeats;

        //The offset to the first beat of the song in seconds
        [SerializeField]
        private float _firstBeatOffset;

        //Conductor instance
        public static Conductor instance;

        public float LoopPositionInAnalog { get { return _loopPositionInAnalog; } }
        public float SongPositionInBeats { get { return _songPositionInBeats; } }

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            //Load the AudioSource attached to the Conductor GameObject
            _musicSource = GetComponent<AudioSource>();

            //Calculate the number of seconds in each beat
            _secPerBeat = 60.0f / _songBpm;

            //Record the time when the music starts
            _dspSongTime = (float)AudioSettings.dspTime;

            //Start the music
            _musicSource.Play();
        }

        private void Update()
        {
            //determine how many seconds since the song started
            _songPosition = (float)(AudioSettings.dspTime - _dspSongTime - _firstBeatOffset);

            //determine how many beats since the song started
            _songPositionInBeats = _songPosition / _secPerBeat;

            //calculate the loop position
            if (_songPositionInBeats >= (_completedLoops + 1) * _beatsPerLoop)
                _completedLoops++;
            _loopPositionInBeats = _songPositionInBeats - _completedLoops * _beatsPerLoop;

            _loopPositionInAnalog = _loopPositionInBeats / _beatsPerLoop;

            if (!_musicSource.isPlaying)
                GameManager.Instance.LoadRewards();
        }
    }
}
