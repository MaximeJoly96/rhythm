using System;
using UnityEngine;

namespace Zenyth.Trajectories
{
    [Serializable]
    public class Segment
    {
        [SerializeField]
        private Vector2[] _positions;

        public Vector2[] Positions
        {
            get { return _positions; }
        }
    }
}
