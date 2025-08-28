using UnityEngine;

namespace UnityEventsAndComponents.BasicComponents
{
[AddComponentMenu("Custom Components/Simple Rotate")]
public class SimpleRotate : MonoBehaviour
{
    [SerializeField] private bool pause;
    [SerializeField] private Vector3 axis;
    [SerializeField] private float degreesPerSecond = 360f;

    private void Update()
    {
        if (pause) return;
        transform.Rotate(axis, degreesPerSecond * Time.deltaTime);
    }

    public void PauseResume(bool pause) => this.pause = pause;
    public void SetAxis(Vector3 newAxis) => axis = newAxis;
    public void SetSpeed(float newDegreesPerSecond) => degreesPerSecond = newDegreesPerSecond;
}
}