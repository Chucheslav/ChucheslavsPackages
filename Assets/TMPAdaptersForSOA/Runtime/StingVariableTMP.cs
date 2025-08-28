using TMPro;
using UnityEngine;

namespace ScriptableObjectArchitecture.MonobehaviourAdapters
{
[RequireComponent(typeof(TextMeshProUGUI))]
public class StingVariableTMP : MonoBehaviour
{
    [SerializeField] private StringVariable variable;
    
    private TextMeshProUGUI text;

    private void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        variable.Link(UpdateText);
    }

    private void UpdateText(string value) => text.text = value;

    private void OnDisable() => variable.Unsubscribe(UpdateText);
}
}