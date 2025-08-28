using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Events/TransformEvent")]
public class TransformEvent : GenericEvent<Transform> { }
}