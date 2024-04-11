using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SmartInput
{
    public class SmartButton  : MonoBehaviour
    {
        public UnityEvent OnButtonHold = new UnityEvent();
        public UnityEvent OnButtonPress = new UnityEvent();
        public UnityEvent OnButtonRelease = new UnityEvent();

        private bool startedHoldHere;

        // Start is called before the first frame update
        void Start()
        {

            InputHandler.Instance.OnScreenHold += OnScreenHold;
            InputHandler.Instance.OnScreenPress += OnScreenPress;
            InputHandler.Instance.OnScreenRelease += OnScreenRelease;
        }

        private void OnScreenRelease()
        {
            if (gameObject.IsPointed())
            {
                OnButtonRelease?.Invoke();
            }
        }

        private void OnScreenHold()
        {
            if (startedHoldHere)
            {
                OnButtonHold?.Invoke();
            }
        }

        private void OnScreenPress()
        {
            startedHoldHere = gameObject.IsPointed();
            if (startedHoldHere)
            {
                OnButtonPress?.Invoke();
            }
        }
    }
}