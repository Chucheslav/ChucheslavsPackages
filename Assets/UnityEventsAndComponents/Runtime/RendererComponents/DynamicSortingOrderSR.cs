using UnityEngine;

namespace UnityEventsAndComponents.RendererComponents
{
[AddComponentMenu("Custom Components/Renderers/Dynamic Sorting Order for Sprite Renderer")]
[RequireComponent(typeof(SpriteRenderer))]
public class DynamicSortingOrderSR: MonoBehaviour
{
    public int adjustment;
    [SerializeField] private float positionMultiplier = 100;

    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _sr.sortingOrder = Screen.height - Mathf.RoundToInt(transform.root.position.y * positionMultiplier) + adjustment;
    }
}
}