using ScriptableObjectArchitecture.Base;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture.MonobehaviourAdapters
{
public class SimpleSimpleEventToUnitySimpleEventConverter : MonoBehaviour, ISimpleEventListener
{
    [SerializeField] private SimpleEvent @event;

    public UnityEvent response;

    private void OnEnable() => @event.RegisterListener(this);

    private void OnDisable() => @event.UnregisterListener(this);

    public void OnEventRaised() => response.Invoke();
}
}
