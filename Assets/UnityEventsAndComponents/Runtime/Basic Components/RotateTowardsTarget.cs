using UnityEngine;

namespace UnityEventsAndComponents.BasicComponents
{
[AddComponentMenu("Custom Components/Rotate Towards Target")]
public class RotateTowardsTarget : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool inverseDirection;

    private void Update()
    {
        Vector3 direction = (transform.position - (target.position + offset)) * (inverseDirection ? 1 : -1);
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
}
