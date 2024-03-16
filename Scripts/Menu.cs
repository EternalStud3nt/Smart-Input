using UnityEngine;

namespace SmartInput
{
    public class Menu : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField] private float animationDuration;

        private bool isOpen = true;
        private RectTransform menuRectTransform;
        private Vector2 originalSize;

        private void Start()
        {
            menuRectTransform = GetComponent<RectTransform>();
            originalSize = menuRectTransform.sizeDelta;

            Close();
        }

        public void Open()
        {
            if (!isOpen)
            {
                LeanTween.value(gameObject, AnimateSize, Vector2.zero, originalSize, animationDuration);
                isOpen = true;
            }
        }

        public void Close()
        {
            if (isOpen)
            {
                LeanTween.value(gameObject, AnimateSize, menuRectTransform.sizeDelta, Vector2.zero, animationDuration);
                isOpen = false;
            }
        }

        private void AnimateSize(Vector2 newSize)
        {
            menuRectTransform.sizeDelta = newSize;
        }
    }
}