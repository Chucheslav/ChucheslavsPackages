using System.Linq;
using UnityEngine;

namespace Tools.SceneTools
{
[RequireComponent(typeof(MeshRenderer))]
public class ColorChangeOnMouseOver : MonoBehaviour
{
    [SerializeField] private Color highlightTint = Color.yellow;
    private MeshRenderer _renderer;
    private Color[] _originalColors;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        
    }

    private void OnMouseEnter()
    {
        _originalColors = _renderer.materials.Select(m => m.color).ToArray();
        for (var i = 0; i < _renderer.materials.Length; i++)
        {
            _renderer.materials[i].color = highlightTint;
        }
    }

    private void OnMouseExit()
    {
        for (var i = 0; i < _renderer.materials.Length; i++)
        {
            _renderer.materials[i].color = _originalColors[i];
        }
    }
}
}
