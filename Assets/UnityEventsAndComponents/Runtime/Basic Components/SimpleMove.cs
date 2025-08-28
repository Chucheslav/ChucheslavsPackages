using UnityEngine;

namespace UnityEventsAndComponents.BasicComponents
{
[AddComponentMenu("Custom Components/Simple Move")]
public class SimpleMove : MonoBehaviour
{
    [SerializeField] private bool pause;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float multiplier = 1f;

    private void Update()
    {
        if (pause) return;
        transform.Translate(velocity * multiplier * Time.deltaTime);
    }

    public void PauseResume(bool pause) => this.pause = pause;
    public void SetVelocity(Vector3 newVelocity) => velocity = newVelocity;
    public void SetMultiplier(float newMultiplier) => multiplier = newMultiplier;
}
}