using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Events/Collider")]
public class ColliderEvent: GenericEvent<Collider>{}
}