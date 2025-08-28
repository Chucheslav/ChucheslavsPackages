using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UITools.Tooltips
{
    [RequireComponent(typeof(LayoutElement))]
    public class Tooltip : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI header;
        [SerializeField] private TextMeshProUGUI content;
        [SerializeField] private int wrapLength;

        private LayoutElement _layout;
        private RectTransform _rectTransform;
        private RectTransform _canvasRT;

        private void Awake()
        {
            _layout = GetComponent<LayoutElement>();
            _rectTransform = GetComponent<RectTransform>();
            _canvasRT = transform.root.GetComponent<RectTransform>();
        }

        private void Update()
        {
            //one way to make window follow cursor within screen
            Vector2 position = Input.mousePosition / _canvasRT.localScale.x;
            if (position.x + _rectTransform.rect.width > _canvasRT.rect.width)
                position.x = _canvasRT.rect.width - _rectTransform.rect.width;
            if (position.y + _rectTransform.rect.height > _canvasRT.rect.height)
                position.y = _canvasRT.rect.height - _rectTransform.rect.height;

            _rectTransform.anchoredPosition = position;

            //another way
            // Vector2 position = Input.mousePosition;
            //
            // _rectTransform.pivot = new Vector2(position.x / Screen.width, position.y / Screen.height);
            // transform.position = position;
        }

        public void SetText(string contentText, string headerText = null)
        {
            header.gameObject.SetActive(!string.IsNullOrEmpty(headerText));
            content.gameObject.SetActive(!string.IsNullOrEmpty(contentText));
            header.text = headerText;
            content.text = contentText;
            //autoresizes tooltip if it is too short
            _layout.enabled = header.text != null && header.text.Length > wrapLength || content.text!= null && content.text.Length > wrapLength; //C# rules
        }

    }
}
