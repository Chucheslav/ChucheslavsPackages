using UnityEngine;

public interface IAmComponent
{
    // ReSharper disable once InconsistentNaming
    public Transform transform { get; }
    // ReSharper disable once InconsistentNaming
    public GameObject gameObject { get; }
}
