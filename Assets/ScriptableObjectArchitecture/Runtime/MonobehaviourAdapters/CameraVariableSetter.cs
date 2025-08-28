using UnityEngine;

namespace ScriptableObjectArchitecture.MonobehaviourAdapters
{
[RequireComponent(typeof(Camera))]
public class CameraVariableSetter : ScriptableVariableSetter<Camera>
{
    protected override void Set()
    {
        base.Set();
        variable.Value = GetComponent<Camera>();
    }
}
}