using ScriptableObjectArchitecture;
using ScriptableObjectArchitecture.Base;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
[CreateAssetMenu(menuName = "SOA/Events/StringEvent")]
public class StringEvent : GenericEvent<string> { }
}