using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Zenyth.Game;

namespace Zenyth.UI
{
    public class Lifebar : MonoBehaviour
    {
        private PlayerController _player;
        private Image _lifeImg;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>();
            _lifeImg = GetComponent<Image>();

            _player.LifeChangedEvent.AddListener(UpdateLifebar);
        }

        private void UpdateLifebar(float change)
        {
            _lifeImg.fillAmount += (change / 100.0f);
        }
    }
}

