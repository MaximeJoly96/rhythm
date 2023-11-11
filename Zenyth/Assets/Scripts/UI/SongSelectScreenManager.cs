using UnityEngine;

namespace Zenyth.UI
{
    public class SongSelectScreenManager : ScreenManager
    {
        [SerializeField]
        private SongsScrollViewer _songsScrollViewer;

        #region Methods
        public override void Init()
        {
            Hide(true);
            gameObject.SetActive(false);
        }
        #endregion
    }
}
