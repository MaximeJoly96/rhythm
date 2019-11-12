using UnityEngine;

namespace Zenyth.Utils
{
    public static class Controls
    {
        public static bool SlowModeActivated
        {
            get { return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift); }
        }

        public static bool ZenythActivated
        {
            get { return Input.GetKey(KeyCode.Space); }
        }
    }
}

