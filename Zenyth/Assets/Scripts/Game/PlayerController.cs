using UnityEngine;
using Zenyth.Utils;

namespace Zenyth.Game
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerStatus _status;

        private static float MOVEMENT_SPEED
        {
            get
            {
                if (Controls.SlowModeActivated)
                    return 2.0f;
                else
                    return 5.0f;
            }
        }

        private void Start()
        {
            _status = GetComponent<PlayerStatus>();
        }

        private void Update()
        {
            float translationX = Input.GetAxis("Horizontal") * Time.deltaTime * MOVEMENT_SPEED;
            float translationY = Input.GetAxis("Vertical") * Time.deltaTime * MOVEMENT_SPEED;

            transform.Translate(translationX, translationY, 0);

            if (Controls.ZenythActivated)
                _status.UseZenyth();
        }
    }
}
