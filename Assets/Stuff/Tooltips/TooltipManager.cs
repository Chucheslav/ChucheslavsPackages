using UnityEngine;

namespace UITools.Tooltips
{
    public class TooltipManager : MonoBehaviour
    {
        [SerializeField] private Tooltip tooltip;
        [SerializeField] private float delay = 0.2f;

        public static float delayTime => _instance.delay;

        private static TooltipManager _instance;

        private void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            tooltip.gameObject.SetActive(false);
        }

        public void SetDelay(float delay) => this.delay = delay;

        public static void Show(string content, string header = null)
        {
            if(!_instance) return;
            _instance.tooltip.gameObject.SetActive(true);
            _instance.tooltip.SetText(content, header);
        }

        public static void Hide()
        {
            if(!_instance) return;
            _instance.tooltip.gameObject.SetActive(false);
        }
    }
}
