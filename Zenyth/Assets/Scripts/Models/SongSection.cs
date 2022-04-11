using System;
using UnityEngine;

namespace Zenyth.Models
{
    [Serializable]
    public class SongSection
    {
        [SerializeField]
        private float _bpm;
        [SerializeField]
        private float _startTiming; // seconds
        [SerializeField]
        private float _offset;

        public float Bpm { get { return _bpm; } }
        public float StartTiming { get { return _startTiming; } }
        public float Offset { get { return _offset; } }

        public SongSection(float bpm, float startTiming, float offset)
        {
            _bpm = bpm;
            _startTiming = startTiming;
            _offset = offset;
        }
    }
}
