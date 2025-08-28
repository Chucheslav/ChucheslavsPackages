using ScriptableObjectArchitecture.Base;
using Tools.Extensions;
using UnityEngine;

namespace ScriptableObjectArchitecture.MonobehaviourAdapters
{
public abstract class ScriptableVariableSetter<T> : MonoBehaviour
{
    [SerializeField] protected FrameTime whenToSet;
    [SerializeField] protected GenericVariable<T> variable;

    protected virtual void Set()
    {
        if(!variable) this.LogError(typeof(T) + " variable field not assigned");
    }

    private void Awake()
    {
        if(whenToSet == FrameTime.Awake) Set();
    }

    private void Start()
    {
        if(whenToSet == FrameTime.Start) Set();
    }

    private void OnEnable()
    {
        if(whenToSet == FrameTime.OnEnable) Set();
    }

    protected enum FrameTime
    {
        Awake,
        OnEnable,
        Start
    }
}
}