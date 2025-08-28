using UnityEngine;

namespace ScriptableObjectArchitecture.MonobehaviourAdapters
{
public class TransformVariableSetter : ScriptableVariableSetter<Transform>
{
    protected override void Set()
    {
        base.Set();
        variable.Value = transform;
    }
}
}