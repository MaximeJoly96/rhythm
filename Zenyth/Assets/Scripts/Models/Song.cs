using UnityEngine;
using System;

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
        private SongSection[] _sections;
        [SerializeField]
        private AudioClip _audio;

        public string Name { get { return _name; } }
        public string Artist { get { return _artist; } }
        public SongSection[] Sections { get { return _sections; } }
        public AudioClip Audio { get { return _audio; } }

        public Song(string name, string artist, SongSection[] sections, AudioClip audio)
        {
            _name = name;
            _artist = artist;
            _audio = audio;
            _sections = sections;
        }
    }
}
