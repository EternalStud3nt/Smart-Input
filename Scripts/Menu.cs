using UnityEngine;

namespace SmartInput
{
    public class Menu : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField] protected float animationDuration;

        protected RectTransform menuRectTransform;
        protected bool IsOpen { get; private set; } = true;

        private Vector2 originalSize;

        protected virtual void Start()
        {
            menuRectTransform = GetComponent<RectTransform>();
            originalSize = menuRectTransform.sizeDelta;

            Close();
        }

        public virtual void Open()
        {
            if (!IsOpen)
            {
                LeanTween.value(gameObject, AnimateSize, Vector2.zero, originalSize, animationDuration);
                IsOpen = true;
            }
        }

        public virtual void Close()
        {
            if (IsOpen)
            {
                LeanTween.value(gameObject, AnimateSize, menuRectTransform.sizeDelta, Vector2.zero, animationDuration);
                IsOpen = false;
            }
        }

        protected virtual void AnimateSize(Vector2 newSize)
        {
            menuRectTransform.sizeDelta = newSize;
        }
    }
}