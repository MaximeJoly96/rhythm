using System;
using UnityEngine;

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
