using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Events/GameObjectEvent")]
public class GameObjectEvent : GenericEvent<GameObject> { }
}