using UnityEngine;
using System;

[Serializable]
public class BpmRange
{
    [SerializeField]
    private float _lowest;
    [SerializeField]
    private float _highest;

    public float Lowest { get { return _lowest; } }
    public float Highest { get { return _highest; } }

    public BpmRange(float low, float high)
    {
        _lowest = low;
        _highest = high;
    }
}
