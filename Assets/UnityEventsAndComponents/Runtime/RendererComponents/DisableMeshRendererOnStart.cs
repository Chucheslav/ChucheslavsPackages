using UnityEngine;

namespace UnityEventsAndComponents.RendererComponents
{
[AddComponentMenu("Custom Components/Renderers/DisableMeshRendererOnStart")]
public class DisableMeshRendererOnStart : MonoBehaviour
{
    private void Start()
    {
        if (TryGetComponent<MeshRenderer>(out MeshRenderer mr)) mr.enabled = false;
    }
}
}
