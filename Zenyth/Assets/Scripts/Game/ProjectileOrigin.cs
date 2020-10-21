using UnityEngine;
using System.Collections;

namespace Zenyth.Game
{
    public class ProjectileOrigin : MonoBehaviour
    {
        [SerializeField]
        private float _startingBeat;
        [SerializeField]
        private float _endBeat;
        [SerializeField]
        private float _beatsInterval;

        [SerializeField]
        private GameObject _projectilePattern;

        private Conductor _conductor;
        private float _timer;

        private void Start()
        {
            _conductor = Conductor.instance;
            _timer = _conductor.SongPositionInBeats;
        }

        private void Update()
        {
            if(_startingBeat <= _conductor.SongPositionInBeats && _endBeat > _conductor.SongPositionInBeats && 
               _conductor.SongPositionInBeats - _timer >= _beatsInterval)
            {
                _timer = _conductor.SongPositionInBeats;
                Instantiate(_projectilePattern, transform);
            }
        }
    }
}

