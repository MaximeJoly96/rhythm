using UnityEngine;
using System;
using System.Collections.Generic;

namespace Zenyth.Models
{
    [Serializable]
    public class Song
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private string _artist;
        [SerializeField]
        private BpmRange _bpmRange;
        [SerializeField]
        private AudioClip _audio;

        public string Key;

        public string Name { get { return _name; } }
        public string Artist { get { return _artist; } }
        public BpmRange BpmRange { get { return _bpmRange; } }
        public AudioClip Audio { get { return _audio; } }
        public List<float> TimeStamps { get; set; }

        public Song(string name, string artist, BpmRange bpmRange, AudioClip audio)
        {
            _name = name;
            _artist = artist;
            _bpmRange = bpmRange;
            _audio = audio;
        }

        public Song(string name, string artist, float lowBpm, float highBpm, AudioClip audio) :
               this(name, artist, new BpmRange(lowBpm, highBpm), audio)
        {

        }
    }
}
