using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Events/RaycastHitEvent")]
public class RaycastHitEvent : GenericEvent<RaycastHit> { }
}