using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityEventsAndComponents.EventsAndCommands
{
[AddComponentMenu("Custom Events/Commands/Misc Commands")]
public class MiscCommands : MonoBehaviour
{
    public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);

    public void ChangeSize(float multiplier) => transform.localScale *= multiplier;

    public void SetGravity3D(bool on)
    {
        if (gameObject.TryGetComponent(out Rigidbody rb)) rb.useGravity = on;
    }

    public void SetGravityScale2D(float scale)
    {
        if (gameObject.TryGetComponent(out Rigidbody2D rb2d)) rb2d.gravityScale = scale;
    }

    public void SetActive(bool on) => gameObject.SetActive(on);

    public void Destroy() => Destroy(gameObject);

    public void SetParent(Transform newParent) => transform.parent = newParent;

    public void UnParent() => transform.parent = null;

    public void QuitApp() => Application.Quit();
}
}