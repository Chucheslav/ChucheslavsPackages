using UnityEngine;

namespace UnityEventsAndComponents.EventsAndCommands
{
[AddComponentMenu("Custom Events/Commands/Material Commands")]
[RequireComponent(typeof(Renderer))]
public class MaterialCommands : MonoBehaviour
{
    [SerializeField] private Color[] materialColors = {Color.white};
    private Renderer _renderer;

    private void Awake()
    {

        _renderer = GetComponent<Renderer>();
    }

    public void ChangeMaterialColor(int index)
    {
        if (index >= materialColors.Length || index < 0)
        {
            Debug.LogError($"Color index {index} does not exist on color changer.");
            return;
        }

        _renderer.material.color = materialColors[index];
    }

    public void ToggleEmission(bool on)
    {
        if (on) _renderer.material.EnableKeyword("_EMISSION");
        else _renderer.material.DisableKeyword("_EMISSION");
    }
}
}
