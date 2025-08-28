using System;
using UnityEngine;

namespace UITools.Tabs
{
    public class TabGroup : MonoBehaviour
    {
        private Tab[] _buttons;
        private TabArea[] _tabs;
        private Tab _selected;
        [SerializeField] private Color highlight;
        [SerializeField] private Color activeColor;
        [SerializeField] private Color inactiveColor;

        private void Start()
        {
            _buttons = GetComponentsInChildren<Tab>();
            _tabs = GetComponentsInChildren<TabArea>(true);
            ResetButtons();
            TabButtonSelected(_buttons[0]);
        }

        public void TabButtonEntered(Tab button)
        {
            ResetButtons();
            button.background.color = highlight;
        }

        public void TabButtonExited(Tab button) => ResetButtons();

        public void TabButtonSelected(Tab button)
        {
            if (button != _selected) _selected?.Deselect();

            _selected = button;
            _selected.Select();
            ResetButtons();
            button.background.color = activeColor;
            int i = Array.IndexOf(_buttons, button);
            if (i < _tabs.Length)
            {
                for (int j = 0; j < _tabs.Length; j++)
                {
                    if (i==j) _tabs[j].gameObject.SetActive(true);
                    else _tabs[j].gameObject.SetActive(false);
                }
            }
            else Debug.Log("Not enough tabs");
        }

        public void ResetButtons()
        {
            foreach (Tab button in _buttons)
            {
                if(_selected!=null && button == _selected) continue;
                button.background.color = inactiveColor;
            }
        } 

    }
}
  