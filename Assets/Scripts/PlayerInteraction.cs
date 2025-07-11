using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private IUsable currentUsable;


    private PlayerInputActions.PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions.PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        inputActions.Player.Interact.performed -= OnInteract;
        inputActions.Disable();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.TryGetComponent<IUsable>(out var usable))
        {
            Debug.Log("Entered usable trigger");
            currentUsable = usable;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<IUsable>() == currentUsable)
        {
           currentUsable = null;

        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        currentUsable?.Use(gameObject);

        Debug.Log("interaction pressed");

    }
}
