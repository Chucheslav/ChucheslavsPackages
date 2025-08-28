using UnityEngine;

namespace UITools
{
    [RequireComponent(typeof(Canvas))]
    public class DynamicSortingOrderCanvas: MonoBehaviour
    {
        public int adjustment;
        [SerializeField] private float positionMultiplier = 100;
        private Canvas _canvas;

        private void Awake()
        {
            _canvas = GetComponent<Canvas>();
        }

        private void Update()
        {
            _canvas.sortingOrder = Screen.height - Mathf.RoundToInt(transform.root.position.y * positionMultiplier ) + adjustment;
        }
    }
}