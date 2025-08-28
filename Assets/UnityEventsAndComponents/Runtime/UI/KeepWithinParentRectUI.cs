using UnityEngine;

namespace UITools
{
[RequireComponent(typeof(RectTransform))]
public class KeepWithinParentRectUI : MonoBehaviour
{
    private RectTransform _this;
    private RectTransform _root;
    
    public void SetPosition(Vector2 screenPosition)
    {
        if(!_this) _this = GetComponent<RectTransform>();
        if(!_root) _root = transform.parent.GetComponent<RectTransform>();
        Vector2 position = screenPosition;
        if (position.x + _this.rect.width > _root.rect.width)
            position.x = _root.rect.width - _this.rect.width;
        if (position.y - _this.rect.height < 0)
            position.y = _this.rect.height;
        
        _this.anchoredPosition = position;
    }
}
}