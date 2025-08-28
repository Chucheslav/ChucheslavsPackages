using UnityEngine;

namespace UnityEventsAndComponents.Runtime.RendererComponents
{
[AddComponentMenu("Custom Components/Renderers/Dynamic Sorting Order for Generic Renderer")]
[RequireComponent(typeof(Renderer))]
public class DynamicSortingOrderRenderer : MonoBehaviour
{
    [SerializeField] private float positionMultiplier = 100;
    
    private Renderer _r;
    public int adjustment;
    // Start is called before the first frame update
    void Start()
    {
        _r = GetComponent<Renderer>();
    }
    
    void Update()
    {
        _r.sortingOrder = Screen.height - Mathf.RoundToInt(transform.root.position.y * positionMultiplier) + adjustment;
    }
}
}