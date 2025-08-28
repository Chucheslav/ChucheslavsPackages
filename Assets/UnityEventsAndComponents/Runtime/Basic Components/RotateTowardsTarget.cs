using UnityEngine;

namespace UnityEventsAndComponents.BasicComponents
{
[AddComponentMenu("Custom Components/Rotate Towards Target")]
public class RotateTowardsTarget : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Vector3 offset;

    private void Update()
    {
        //transform.rotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        transform.LookAt(target.position + offset);
    }
}
}
