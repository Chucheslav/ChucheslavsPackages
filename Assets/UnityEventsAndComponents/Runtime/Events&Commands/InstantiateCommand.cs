using UnityEngine;

namespace UnityEventsAndComponents.EventsAndCommands
{
[AddComponentMenu("Custom Events/Commands/Instantiate Command")]
public class InstantiateCommand : MonoBehaviour
{
    [SerializeField] private Transform positionMarker;

    [SerializeField] [Tooltip("only used if marker is not set")]
    private Vector3 position;

    [SerializeField] private Transform optionalParent;
    [SerializeField] private GameObject prefab;

    public void Instantiate()
    {
        Quaternion r = positionMarker ? positionMarker.transform.rotation : Quaternion.identity;
        Vector3 p = positionMarker ? positionMarker.transform.position : position;

        Instantiate(prefab, p, r, optionalParent);
    }
}
}
