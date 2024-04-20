using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SmartInput
{
    public class InputHandler : Singleton<InputHandler>
    {
        [SerializeField] protected InputActionAsset inputActionAsset;

        protected InputActionMap actionMap;
        protected InputAction pointAction;
        protected InputAction pressAction;
        protected InputAction holdAction;

        public event Action OnScreenPress;
        public event Action OnScreenRelease;
        public event Action OnScreenHold;

        public Vector2 PointerPosition { get; protected set; }

        protected override void Awake()
        {
            base.Awake();
            FindInputActions();
            HandleInputActions();
        }

        protected virtual void FindInputActions()
        {
            actionMap = inputActionAsset.FindActionMap("Screen");

            // Actions
            pointAction = actionMap.FindAction("Point");
            pressAction = actionMap.FindAction("Press");
            holdAction = actionMap.FindAction("Hold");
        }

        protected virtual void HandleInputActions()
        {
            // Point
            pointAction.performed += context => PointerPosition = context.ReadValue<Vector2>();

            // Press
            pressAction.performed += context => OnScreenPress.Invoke();
            pressAction.canceled += context => OnScreenRelease.Invoke();

            // Hold
            holdAction.performed += context => OnScreenHold.Invoke();
        }

        protected virtual void OnEnable()
        {
            pointAction.Enable();
            pressAction.Enable();
            holdAction.Enable();
        }

        protected virtual void OnDisable()
        {
            pointAction.Disable();
            pressAction.Disable();
            holdAction.Disable();
        }

    }
}