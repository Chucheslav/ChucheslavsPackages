using TMPro;
using UnityEngine;

namespace UnityEventsAndComponents
{
[AddComponentMenu( "Custom Events/Commands/TMP Text Commands" )]
[RequireComponent(typeof(TextMeshProUGUI))]
public class TMPTextCommands : MonoBehaviour
{
    [SerializeField] private string format = "F1";
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    
    public void SetTextFromFloat( float value ) =>
    _text.text = value.ToString(format);
    
    public void SetTextFromInt( int value ) => _text.text = value.ToString();
    
    public void SetToGameObjectName( GameObject value ) => _text.text = value.name;
    
}
}
