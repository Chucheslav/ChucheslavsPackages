using UnityEngine;

public class SimpleUIMouseFollow : MonoBehaviour
{
    private void Update()
    {
        transform.position = Input.mousePosition;
    }
}
