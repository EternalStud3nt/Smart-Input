using UnityEngine;
using UnityEngine.InputSystem;

public class ActionTester : MonoBehaviour
{
    [SerializeField] private InputAction action;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        action.Enable();
        spriteRenderer = GetComponent<SpriteRenderer>();

        action.started += ctx => spriteRenderer.color = Color.yellow;
        action.performed += ctx => spriteRenderer.color = Color.green;
        action.canceled += ctx => spriteRenderer.color = Color.red;
    }

    private void OnDisable()
    {
        action.Disable();
    }
}
