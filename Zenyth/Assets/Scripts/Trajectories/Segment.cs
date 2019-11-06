using System;
using UnityEngine;


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
