using UnityEngine;

namespace UnityEventsAndComponents.RendererComponents
{
[AddComponentMenu("Custom Components/Renderers/Disable Mesh Renderer On Start")]
public class DisableMeshRendererOnStart : MonoBehaviour
{
    private void Start()
    {
        if (TryGetComponent<MeshRenderer>(out MeshRenderer mr)) mr.enabled = false;
    }
}
}
