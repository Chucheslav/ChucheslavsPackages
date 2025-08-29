using System;
using UnityEngine;
using UnityEngine.Events;

namespace UnityEventsAndComponents.EventsAndCommands
{
[AddComponentMenu("Custom Events/Triggers/Keyboard Key Event")]
public class KeyboardKeyEvent : MonoBehaviour
{
    [SerializeField] private string buttonName;
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private EventType eventType;
    [SerializeField] private UnityEvent buttonEvent;

    [Header("Vector 3 event")] [SerializeField]
    public Vector3UnityEvent vector3Event;

    [SerializeField] private Vector3 eventValue;

    private void OnEnable()
    {
        SetKeyCode();
    }

    private void OnValidate()
    {
        SetKeyCode();
    }

    private void SetKeyCode()
    {
        if (!String.IsNullOrWhiteSpace(buttonName) && Enum.TryParse<KeyCode>(buttonName, true, out KeyCode result))
            keyCode = result;
        else Debug.LogWarning("ButtonEvent unable to parse button name on " + gameObject.name);
    }

    private void Update()
    {
        bool shouldSend = (eventType == EventType.OnButtonDown && Input.GetKeyDown(keyCode))
                          || (eventType == EventType.OnButtonHeld && Input.GetKey(keyCode))
                          || (eventType == EventType.OnButtonUp && Input.GetKeyUp(keyCode));
        if (shouldSend)
        {
            buttonEvent.Invoke();
            vector3Event.Invoke(eventValue);
        }
    }

    private enum EventType
    {
        OnButtonDown,
        OnButtonHeld,
        OnButtonUp
    }
}
}
