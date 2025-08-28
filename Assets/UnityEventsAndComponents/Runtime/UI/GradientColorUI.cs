using UnityEngine;
using UnityEngine.UI;

namespace UITools
{
public class GradientColorUI : MonoBehaviour
{
    [SerializeField] private Gradient colorGradient;
    [SerializeField] [Range(0, 1f)] private float value;
    [SerializeField] private Image thisImage;
    
    private void Awake()
    {
        if(!thisImage || !TryGetComponent(out thisImage)) thisImage = GetComponentInChildren<Image>();
    }

    private void OnValidate()
    {
        if(thisImage || TryGetComponent(out thisImage))
            thisImage.color = colorGradient.Evaluate(value);
    }

    public void SetColor(float gradient)
    {
        value = Mathf.Clamp01(gradient);
        thisImage.color = colorGradient.Evaluate(value);
    }
}
}
