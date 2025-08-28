using UnityEngine;

namespace ScriptableObjectArchitecture.Base
{
public abstract class ScriptableEnum: ScriptableObject
{
    [field:SerializeField]public string DisplayName { get; private set; }
}
}