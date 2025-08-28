using TMPro;
using UnityEngine;

namespace ScriptableObjectArchitecture.MonobehaviourAdapters
{
[RequireComponent(typeof(TextMeshProUGUI))]
public class FloatVariableTMP : MonoBehaviour
{
    [SerializeField] private FloatVariable floatVariable;
    [SerializeField] private string formatString = "F1";
    private TextMeshProUGUI text;

    private void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        floatVariable.Link(UpdateText);
    }

    private void UpdateText(float value) => text.text = value.ToString(formatString);

    private void OnDisable() => floatVariable.Unsubscribe(UpdateText);
}
}