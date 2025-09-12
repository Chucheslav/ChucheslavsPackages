using TMPro;
using UnityEngine;

namespace UnityEventsAndComponents
{
[AddComponentMenu( "Custom Events/Commands/TMP Text Commands" )]
[RequireComponent(typeof(TextMeshProUGUI))]
public class TMPTextCommands : MonoBehaviour
{
    [SerializeField] private string format = "F1";
    [SerializeField] private Color[] colors = { Color.white };
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    
    public void SetTextFromFloat( float value ) =>
    _text.text = value.ToString(format);
    
    public void SetTextFromInt( int value ) => _text.text = value.ToString();
    
    public void SetToGameObjectName( GameObject value ) => _text.text = value.name;
    
    public void SetColor( int index )
    {
        if (index < 0 || index >= colors.Length)
        {
            Debug.LogError( $"Color index {index} does not exist on color changer." );
            return;
        }
        
        _text.color = colors[index];
    }
}
}
