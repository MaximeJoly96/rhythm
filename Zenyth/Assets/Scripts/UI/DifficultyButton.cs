using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using Zenyth.Core;

namespace Zenyth.UI
{
    public class DifficultyButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {
        #region Private members
        private Text _text;

        [SerializeField]
        private GameManager.Difficulty _difficulty;
        #endregion

        #region Events
        public UnityEvent<GameManager.Difficulty> DifficultySelectedEvent { get; private set; }
        #endregion

        private void Awake()
        {
            _text = GetComponent<Text>();
            DifficultySelectedEvent = new UnityEvent<GameManager.Difficulty>();
        }

        public void SelectDifficulty()
        {
            DifficultySelectedEvent.Invoke(_difficulty);
        }

        public void OnPointerEnter(PointerEventData point)
        {
            _text.color = Color.black;
        }

        public void OnPointerExit(PointerEventData point)
        {
            _text.color = Color.white;
        }

        public void OnPointerDown(PointerEventData point)
        {
            SelectDifficulty();
        }
    }
}
