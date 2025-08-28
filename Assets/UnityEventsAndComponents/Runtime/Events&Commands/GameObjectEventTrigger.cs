using UnityEngine;
using UnityEngine.Events;

namespace UnityEventsAndComponents.EventsAndCommands
{
[AddComponentMenu("Custom Events/Triggers//GameObject Event Trigger")]
public class GameObjectEventTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent triggeredEvent;
    [SerializeField] private EventType eventType;

    [Header("Vector 3 event")] [SerializeField]
    public Vector3UnityEvent vector3Event;

    [SerializeField] private Vector3 eventValue;

    private void Awake()
    {
        if (eventType != EventType.OnAwake) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void OnEnable()
    {
        if (eventType != EventType.OnEnable) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void Start()
    {
        if (eventType != EventType.OnStart) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void OnDisable()
    {
        if (eventType != EventType.OnDisable) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void OnDestroy()
    {
        if (eventType != EventType.OnDestroy) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void Update()
    {
        if (eventType != EventType.OnUpdate) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void FixedUpdate()
    {
        if (eventType != EventType.OnFixedUpdate) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private void LateUpdate()
    {
        if (eventType != EventType.OnLateUpdate) return;
        triggeredEvent.Invoke();
        vector3Event.Invoke(eventValue);
    }

    private enum EventType
    {
        OnAwake,
        OnStart,
        OnEnable,
        OnDisable,
        OnDestroy,
        OnUpdate,
        OnFixedUpdate,
        OnLateUpdate
    }
}
}
