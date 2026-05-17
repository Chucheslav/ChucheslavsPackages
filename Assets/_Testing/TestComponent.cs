using System.Collections.Generic;
using Tools;
using UnityEngine;

public class TestComponent : MonoBehaviour
{
    public List<int> ints = new();
    [MinMax(0,1)] public Vector2 minMax;
    
    
    void Start()
    {
        Debug.Log(ints.TryFindFirst(i => i == 0, out int _));
        ints.WeightedRandom(i => i);
    }
}
