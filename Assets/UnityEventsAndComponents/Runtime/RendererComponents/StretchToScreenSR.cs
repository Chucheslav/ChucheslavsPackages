using UnityEngine;

namespace UnityEventsAndComponents.Runtime.RendererComponents
{
[AddComponentMenu("Custom Components/Renderers/Stretch Sprite Renderer To Screen")]
[RequireComponent(typeof(SpriteRenderer))]
public class StretchToScreenSR : MonoBehaviour
{
    [SerializeField] private Camera stretchCamera;

    [Header("<=0 to switch off, 1 to screen size")]
    [SerializeField] private float stretchHorizontal;

    [SerializeField] private float stretchVertical;
    
    [SerializeField] private bool stretchOnAwake;
    
    private SpriteRenderer _sr;

    public Vector2 Size => _sr.bounds.size;


    private void OnValidate()
    {
        Init();
        if(stretchOnAwake) Stretch();
    }

    private void Awake()
    {
        Init();
        if(stretchOnAwake) Stretch();
    }

    public void Init()
    {
        _sr = GetComponent<SpriteRenderer>();
        if(!stretchCamera) stretchCamera = Camera.main;
    }

    public void SetAndStretch(float horizontalFactor, float verticalFactor)
    {
        stretchHorizontal = horizontalFactor;
        stretchVertical = verticalFactor;
        Stretch();
    }

    public void Stretch()
    {
        float camSize = stretchCamera.orthographicSize * 2.0f;
        Vector3 newScale = transform.localScale;
        if (stretchHorizontal > 0) newScale.x = stretchHorizontal * camSize * Screen.width / Screen.height / _sr.bounds.size.x;
        if (stretchVertical > 0)
            newScale.y = stretchVertical * camSize / _sr.bounds.size.y;
        transform.localScale = newScale;
    }
}}
