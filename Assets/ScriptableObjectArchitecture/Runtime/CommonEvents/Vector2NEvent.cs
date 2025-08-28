using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Events/Vector2?Event")]
public class Vector2NEvent : GenericEvent<Vector3?> { }
}