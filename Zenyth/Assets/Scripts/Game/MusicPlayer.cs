using UnityEngine;
using Zenyth.Models;

namespace Zenyth.Game
{
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField]
        private Song _song;

        private AudioSource _source;

        public Song Song { get { return _song; } }

        private void Awake()
        {
            _source = GetComponent<AudioSource>();
        }

        public void PlayMusic()
        {
            _source.clip = _song.Audio;
            _source.Play();
        }
    }
}
