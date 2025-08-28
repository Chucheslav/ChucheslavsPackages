using UnityEngine;

namespace UITools
{
public class GameObjectActiveToggleButton : UIButton
{
    [SerializeField] private GameObject toToggle;

    protected override void OnClick()
    {
        base.OnClick();
        toToggle.SetActive(!toToggle.activeSelf);
    }
}
}
