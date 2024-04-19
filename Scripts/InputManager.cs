using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SmartInput
{
    public class InputManager : MonoBehaviour
    {

        private Vector2 pointerPosition => inputHandler.PointerPosition;

        protected InputHandler inputHandler;

        public static InputManager Instance { get; private set; }
        public bool IsPointerOverUI => EventSystem.current.IsPointerOverGameObject();
        public Vector2 DragStartPos { get; private set; }
        public Vector2 Drag { get; private set; }
        public bool PressingScreen { get; private set; }


        public virtual List<RaycastResult> RaycastPointer()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = pointerPosition;
            List<RaycastResult> raysastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, raysastResults);
            return raysastResults;
        }

        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            PressingScreen = false;
            inputHandler.OnScreenPress += OnScreenPress;
            inputHandler.OnScreenRelease += OnScreenRelease;
            inputHandler.OnScreenHold += OnScreenHold;
        }

        protected virtual void OnScreenHold()
        {

        }

        protected virtual void OnScreenRelease()
        {
            PressingScreen = false;
            Drag = Vector2.zero;
        }

        protected virtual void OnScreenPress()
        {
            Drag = pointerPosition;
            DragStartPos = pointerPosition;
            PressingScreen = true;
        }

        protected virtual void Update()
        {
            if(PressingScreen)
            {
                Vector2 _drag = Camera.main.ScreenToWorldPoint(pointerPosition) - Camera.main.ScreenToWorldPoint(DragStartPos);
                Drag = new Vector2(_drag.x, _drag.y);
            }
        }

        protected virtual void OnDestroy()
        {
            inputHandler.OnScreenPress -= OnScreenPress;
            inputHandler.OnScreenRelease -= OnScreenRelease;
            inputHandler.OnScreenHold -= OnScreenHold;
        }

    }
}