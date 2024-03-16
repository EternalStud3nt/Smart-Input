using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SmartInput
{
    public class InputHandler : MonoBehaviour
    {
        [SerializeField] private InputActionAsset inputActionAsset;

        private InputActionMap actionMap;
        private InputAction pointAction;
        private InputAction pressAction;
        private InputAction holdAction;

        public event Action OnScreenPress;
        public event Action OnScreenRelease;
        public event Action OnScreenHold;

        public Vector2 PointerPosition { get; private set; }
        public static InputHandler Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            actionMap = inputActionAsset.FindActionMap("Screen");

            // Actions
            pointAction = actionMap.FindAction("Point");
            pressAction = actionMap.FindAction("Press");
            holdAction = actionMap.FindAction("Hold");

            RegisterInputActions();
        }

        private void RegisterInputActions()
        {
            // Point
            pointAction.performed += context => PointerPosition = context.ReadValue<Vector2>();

            // Press
            pressAction.performed += context => OnScreenPress.Invoke();
            pressAction.canceled += context => OnScreenRelease.Invoke();

            // Hold
            holdAction.performed += context => OnScreenHold.Invoke();
        }

        private void OnEnable()
        {
            pointAction.Enable();
            pressAction.Enable();
            holdAction.Enable();
        }

        private void OnDisable()
        {
            pointAction.Disable();
            pressAction.Disable();
            holdAction.Disable();
        }

    }
}