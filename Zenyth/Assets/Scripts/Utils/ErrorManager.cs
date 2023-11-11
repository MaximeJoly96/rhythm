using UnityEngine;

namespace Zenyth.Utils
{
    public static class ErrorManager
    {
        #region Methods
        public static void HandleError(string message)
        {
            Debug.LogError(message);
        }
        #endregion
    }
}
