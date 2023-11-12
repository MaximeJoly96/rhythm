using UnityEngine;
using UnityEngine.SceneManagement;
using Zenyth.Core;

namespace Zenyth.UI.Rewards
{
    public class RewardsBackButton : MonoBehaviour
    {
        #region Methods
        public void BackToSongSelect()
        {
            AmbianceManager.Instance.PlayValidation();
            SceneManager.LoadScene("TitleScreen");
        }
        #endregion
    }
}
