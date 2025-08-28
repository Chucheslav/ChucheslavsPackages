using UnityEngine;

namespace UnityEventsAndComponents.BasicComponents
{
[AddComponentMenu("Custom Components/Don't Destroy On Load")]
public class DontDestroyOnLoad:MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
}