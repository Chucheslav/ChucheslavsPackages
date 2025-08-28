using UnityEngine;
using UnityEngine.Events;

namespace UnityEventsAndComponents.EventsAndCommands
{
[AddComponentMenu("Custom Events/Triggers/Collider2D Event Trigger")]
public class Collider2DEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent triggeredEvent;
    [SerializeField] private EventType eventType;
    
    [Header("Vector3 event")]
    [SerializeField] public Vector3UnityEvent vector3Event;
    [SerializeField] private Vector3 eventValue;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(eventType != EventType.OnCollisionEnter ) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(eventType != EventType.OnCollisionExit ) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void OnCollisionStay2D(Collision2D collisionInfo)
    {
        if(eventType != EventType.OnCollisionStay ) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(eventType != EventType.OnTriggerEnter) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(eventType != EventType.OnTriggerExit ) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(eventType != EventType.OnTriggerStay ) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private enum EventType
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