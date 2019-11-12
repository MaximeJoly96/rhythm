using UnityEngine;
using UnityEngine.UI;

namespace Zenyth.UI
{
    public class TextFader : MonoBehaviour
    {
        private Text _text;
        private float _progress;

        private Color _from;
        private Color _to;

        private void Awake()
        {
            _text = GetComponent<Text>();

            _from = _text.color;
            _to = Color.clear;
        }

        private void Update()
        {
            _progress += Time.deltaTime * 0.25f;
            _text.color = Color.Lerp(_from, _to, _progress);

            if (_progress >= 1.0f)
            {
                _progress = 0.0f;

                Color temp = _from;
                _from = _to;
                _to = temp;
            }  
        }
    }
}

