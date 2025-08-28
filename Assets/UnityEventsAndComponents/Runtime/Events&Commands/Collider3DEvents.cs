using UnityEngine;
using UnityEngine.Events;

namespace UnityEventsAndComponents.EventsAndCommands
{
[AddComponentMenu("Custom Events/Triggers/Collider3D Event Trigger")]
public class Collider3DEvents : MonoBehaviour
{
    public UnityEvent triggeredEvent;
    public EventType eventType;

    [Header("Vector 3 event")] [SerializeField]
    public Vector3UnityEvent vector3Event;

    [SerializeField] private Vector3 eventValue;

    private void OnCollisionEnter(Collision collision)
    {
        if (eventType != EventType.OnCollisionEnter) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void OnCollisionExit(Collision other)
    {
        if (eventType != EventType.OnCollisionExit) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (eventType != EventType.OnCollisionStay) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (eventType != EventType.OnTriggerEnter) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void OnTriggerExit(Collider other)
    {
        if (eventType != EventType.OnTriggerExit) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void OnTriggerStay(Collider other)
    {
        if (eventType != EventType.OnTriggerStay) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    public enum EventType
    {
        OnCollisionEnter,
        OnCollisionExit,
        OnCollisionStay,
        OnTriggerEnter,
        OnTriggerExit,
        OnTriggerStay,
    }
}
}