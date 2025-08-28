using System.Collections;
using Tools.Coroutines;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UITools.Tooltips
{
    /// <summary>
    /// add this to UI element that will show the tooltip, call Set() to set tooltip header and text
    /// </summary>
    public class TooltipTriggerUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]private string content;
        [SerializeField]private string header;
        private CoroutineHandle _delay;

        public void Set(string content, string header = null)
        {
            this.content = content;
            this.header = header;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(string.IsNullOrEmpty(content)) return;
            _delay = new CoroutineHandle(ShowDelay(TooltipManager.delayTime));
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if(_delay is {Running: true}) _delay.Stop();
            TooltipManager.Hide();
        }

        private IEnumerator ShowDelay(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            TooltipManager.Show(content, header);
        }
    }
}