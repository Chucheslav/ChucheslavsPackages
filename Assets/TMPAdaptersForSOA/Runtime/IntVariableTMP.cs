using TMPro;
using UnityEngine;

namespace ScriptableObjectArchitecture.MonobehaviourAdapters
{
[RequireComponent(typeof(TextMeshProUGUI))]
public class IntVariableTMP : MonoBehaviour
{
    [SerializeField] private IntVariable intVariable;
    private TextMeshProUGUI text;

    private void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();
        intVariable.Link(UpdateText);
    }

    private void UpdateText(int value) => text.text = value.ToString();

    private void OnDisable() => intVariable.Unsubscribe(UpdateText);
}
}