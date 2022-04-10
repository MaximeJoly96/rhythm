using UnityEngine;
using System.Collections;

namespace Zenyth.UI
{
    public class ScrollViewSongs : MonoBehaviour
    {
        public void Hide(bool hide)
        {
            gameObject.SetActive(!hide);
        }
    }
}
