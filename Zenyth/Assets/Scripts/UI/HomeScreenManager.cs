using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Zenyth.UI
{
    public class HomeScreenManager : ScreenManager
    {
        [SerializeField]
        private Text _title;
        [SerializeField]
        private Text _pressKeyText;

        private UnityEvent _anyKeyPressedEvent;

        public UnityEvent AnyKeyPressedEvent
        {
            get
            {
                if (_anyKeyPressedEvent == null)
                    _anyKeyPressedEvent = new UnityEvent();

                return _anyKeyPressedEvent;
            }
        }

        private void Update()
        {
            if(GameController.CurrentGameState == Game.GameController.GameState.HomeScreen && Input.anyKeyDown)
            {
                AnyKeyPressedEvent.Invoke();
            }
        }
    }
}
