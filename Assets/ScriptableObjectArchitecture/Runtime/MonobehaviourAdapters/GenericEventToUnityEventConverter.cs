using ScriptableObjectArchitecture.Base;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture.MonobehaviourAdapters
{
public abstract class GenericEventToSceneUnityEventConverter<T> : MonoBehaviour
{
    [SerializeField] private GenericEvent<T> @event;

    public UnityEvent<T> response;

    private void OnEnable() => @event.Subscribe(Convert);

    private void Convert(T value)
    {
        response.Invoke(value);
    }

    private void OnDisable() => @event.Unsubscribe(Convert);
    
}
}