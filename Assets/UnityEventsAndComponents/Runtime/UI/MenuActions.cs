using System.IO;
using UnityEditor;
using UnityEngine;

namespace Tools.Editor
{
    public static class MenuActions
    {
        [MenuItem("CONTEXT/" + nameof(RectTransform) + "/AnchorsToCorners")]
        static void AnchorsToCorners(MenuCommand command)
        {
            RectTransform rt = (RectTransform) command.context;
            RectTransform prt = (RectTransform) rt.parent;
            if (prt == null)
            {
                Debug.Log("RectTransform is root - use built in anchor functions");
                return;
            }
            rt.anchorMin = new Vector2(rt.anchorMin.x + rt.offsetMin.x / prt.rect.width,
                rt.anchorMin.y + rt.offsetMin.y / prt.rect.height);
            rt.anchorMax = new Vector2(rt.anchorMax.x + rt.offsetMax.x / prt.rect.width,
                rt.anchorMax.y + rt.offsetMax.y / prt.rect.height);

            rt.offsetMin = rt.offsetMax = new Vector2(0,0);
        }

        [MenuItem("CONTEXT/" + nameof(SpriteRenderer) + "/ResizeToParentSR")]
        static void ResizeToParentSR(MenuCommand command)
        {
            SpriteRenderer targetSR = (SpriteRenderer) command.context;
            Transform targetTransform = targetSR.transform;
            Transform parent = targetTransform.parent;
            if (!parent)
            {
                Debug.Log("Object doesn't have parent to resize to, aborting");
                return;
            }
            if (!parent.TryGetComponent(out SpriteRenderer parentSR))
            {
                Debug.Log("Parent doesnt have SpriteRenderer, aborting");
                return;
            }
        
            targetTransform.localScale = Vector3.one;
            targetTransform.localScale *= parentSR.sprite.rect.size / targetSR.sprite.rect.size *
                targetSR.sprite.pixelsPerUnit / parentSR.sprite.pixelsPerUnit;
            targetTransform.localPosition = Vector3.zero;
        }
    }
}
