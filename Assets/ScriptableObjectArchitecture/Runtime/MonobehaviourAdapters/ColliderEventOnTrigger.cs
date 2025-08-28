using System;
using UnityEngine;

namespace ScriptableObjectArchitecture.MonobehaviourAdapters
{
[RequireComponent(typeof(Collider))]
public class ColliderEventOnTrigger : MonoBehaviour
{
    [SerializeField] private ColliderEvent colliderEvent;

    private Collider _thisCollider;

    private void Awake()
    {
        _thisCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!other.isTrigger) colliderEvent.Raise(_thisCollider);
    }
}
}

