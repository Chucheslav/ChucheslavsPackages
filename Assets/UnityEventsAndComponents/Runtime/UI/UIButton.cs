using UnityEngine;
using UnityEngine.UI;

namespace UITools
{
    [RequireComponent(typeof(Button))]
    public abstract class UIButton : MonoBehaviour
    {
        protected virtual void Awake()
        {
            GetComponent<Button>().onClick.AddListener(OnClick);
        }

        protected virtual void OnClick(){}
    }
}