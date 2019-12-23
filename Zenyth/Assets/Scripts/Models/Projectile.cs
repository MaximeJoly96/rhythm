using UnityEngine;
using System.Collections;
using Zenyth.Trajectories;
using Zenyth.Game;

namespace Zenyth.Models
{
    [System.Serializable]
    public class Projectile : PooledObject
    {
        [SerializeField]
        private Trajectory _trajectory;

        public Trajectory Trajectory { get { return _trajectory; } }

        public override void CleanUp()
        {
            _trajectory = null;
        }
    }
}
