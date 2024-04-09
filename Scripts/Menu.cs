using UnityEngine;

namespace SmartInput
{
    public class Menu : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField] protected float animationDuration;

        protected RectTransform menuRectTransform;
        protected bool isOpen { get; private set; } = true;

        private Vector2 originalSize;

        protected virtual void Start()
        {
            menuRectTransform = GetComponent<RectTransform>();
            originalSize = menuRectTransform.sizeDelta;

            Close();
        }

        public virtual void Open()
        {
            if (!isOpen)
            {
                LeanTween.value(gameObject, AnimateSize, Vector2.zero, originalSize, animationDuration);
                isOpen = true;
            }
        }

        public virtual void Close()
        {
            if (isOpen)
            {
                LeanTween.value(gameObject, AnimateSize, menuRectTransform.sizeDelta, Vector2.zero, animationDuration);
                isOpen = false;
            }
        }

        protected virtual void AnimateSize(Vector2 newSize)
        {
            menuRectTransform.sizeDelta = newSize;
        }
    }
}