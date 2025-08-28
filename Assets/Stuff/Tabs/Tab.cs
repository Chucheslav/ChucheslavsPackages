using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UITools.Tabs
{
    [RequireComponent(typeof(Image))]
    public class Tab : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        public bool disabled;
        public TextMeshProUGUI label { get; private set; }
        //public TabArea tabArea;
        public Image background;

        public UnityEvent onTabSelected;
        public UnityEvent onTabDeselected;
    
        private TabGroup _group;

        private void Awake()
        {
            
            background = GetComponent<Image>();
            _group = transform.parent.GetComponentInParent<TabGroup>();
            label = GetComponentInChildren<TextMeshProUGUI>();
            if(disabled) gameObject.SetActive(false);
        }
    
        public void OnPointerEnter(PointerEventData eventData) => _group.TabButtonEntered(this);

        public void OnPointerExit(PointerEventData eventData) => _group.TabButtonExited(this);

        public void OnPointerDown(PointerEventData eventData) => _group.TabButtonSelected(this);

        public void Select() => onTabSelected?.Invoke();

        public void Deselect() => onTabDeselected?.Invoke();
    }
}
