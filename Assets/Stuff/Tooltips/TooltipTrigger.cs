using System.Collections;
using Tools.Coroutines;
using UnityEngine;

namespace UITools.Tooltips
{
    public class TooltipTrigger : MonoBehaviour
    {
        private string _content;
        private string _header;
        private CoroutineHandle _delay;

        public void Set(string content, string header = null)
        {
            _content = content;
            _header = header;
        }

        public void OnMouseEnter()
        {
            if(string.IsNullOrEmpty(_content)) return;
            _delay = new CoroutineHandle(ShowDelay(TooltipManager.delayTime));
        }

        public void OnMouseExit()
        {
            if(_delay is {Running: true}) _delay.Stop();
            TooltipManager.Hide();
        }

        private IEnumerator ShowDelay(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            TooltipManager.Show(_content, _header);
        }
    }
}