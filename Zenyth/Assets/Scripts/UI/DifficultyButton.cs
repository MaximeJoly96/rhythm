using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Zenyth.UI
{
    public class DifficultyButton : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField]
        private Utils.Utils.Difficulty _difficulty;

        private Text _text;
        private TitleScreenManager _titleScreenManager;

        private void Awake()
        {
            _text = GetComponent<Text>();
            _titleScreenManager = FindObjectOfType<TitleScreenManager>();
        }

        public void SelectDifficulty()
        {
            _titleScreenManager.DifficultySelected(_difficulty);
        }

        public void OnMouseOver()
        {
            _titleScreenManager.UpdateDifficultyName(_difficulty.ToString());
        }

        public void OnPointerDown(PointerEventData point)
        {
            SelectDifficulty();
        }
    }
}
