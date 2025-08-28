using UnityEngine;

namespace UnityEventsAndComponents.EventsAndCommands
{
[AddComponentMenu("Custom Events/Commands/Vector3 Commands")]
public class Vector3Commands : MonoBehaviour
{
    public void Translate(Vector3 delta) => transform.Translate(delta);
    
    public void SetPosition(Vector3 newPosition) => transform.position = newPosition;
    
    /// <summary>
    /// Vector direction is rotation axis, vector magnitude is degrees
    /// </summary>
    public void RotateAxis(Vector3 axis) => transform.Rotate(axis, axis.magnitude);
    
    public void RotateEulers(Vector3 eulers) => transform.Rotate(eulers);

    public void SetScale(Vector3 newScale) => transform.localScale = newScale;
}
}
