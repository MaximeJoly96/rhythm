using UnityEngine;

namespace Zenyth.Game
{
    public class PlayerStatus : MonoBehaviour
    {
        private bool _zenyth;
        private float _life;

        public float Life
        {
            get { return _life; }
            set
            {
                _life = value;
                _life = Mathf.Clamp(_life, 0.0f, 100.0f);
            }
        }

        public void UseZenyth()
        {
            _zenyth = true;
        }

        public void TakeDamage(float dmg)
        {
            Life -= dmg;
        }

        public void RestoreHealth(float restore)
        {
            Life += restore;
        }
    }
}
