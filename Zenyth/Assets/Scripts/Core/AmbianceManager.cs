using UnityEngine;
using Zenyth.Utils;

namespace Zenyth.Core
{
    public class AmbianceManager : MonoBehaviour
    {
        #region Private members
        private AudioSource _source;

        [SerializeField]
        private AudioClip _validationSound;
        #endregion

        #region Properties
        private AudioSource Source
        {
            get
            {
                if (_source == null)
                    _source = GetComponent<AudioSource>();

                if (_source != null)
                    return _source;

                ErrorManager.HandleError("No Audio source attached to AmbianceManager gameObject.");
                return null;
            }
        }

        public static AmbianceManager Instance { get; private set; }
        #endregion

        #region Methods
        private void Awake()
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }

        public void SetAudio(AudioClip clip)
        {
            Source.clip = clip;
        }

        public void PlayAudio(float volume)
        {
            Source.volume = volume;
            Source.Play();
        }

        public void PlayValidation()
        {
            Source.PlayOneShot(_validationSound);
        }
        #endregion
    }
}
