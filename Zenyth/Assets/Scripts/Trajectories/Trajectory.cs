using System;
using UnityEngine;

namespace Zenyth.Trajectories
{
    [Serializable]
    public class Trajectory
    {
        [SerializeField]
        private Segment[] _segments;

        public Segment[] Segments
        {
            get { return _segments; }
        }
    }
}
