using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Tools
{
public class SRClickInterceptor : MonoBehaviour, IPointerDownHandler
{
    
    [SerializeField] private UnityEvent<Vector3> clickedPositionEvent;
    
    public event Action<Vector3> ClickedAt;

    public void OnPointerDown(PointerEventData eventData)
    {
        ClickedAt?.Invoke(eventData.position);
        clickedPositionEvent.Invoke(eventData.position);
    }
    
}
}
