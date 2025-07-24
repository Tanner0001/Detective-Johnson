using UnityEngine;
using UnityEngine.InputSystem;


// this script acts as a testing grounds for object placing using the command pattren structure.
public class ObjectPlacer : MonoBehaviour
{
    public GameObject objectPrefab;
    public Camera cam;

    private PlayerInputActions.PlayerInputActions input;

    private void Awake()
    {
        input = new PlayerInputActions.PlayerInputActions();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Next.performed += ctx => PlaceMarker(); 
        input.Player.Previous.performed += ctx => CommandInvoker.Instance.UndoLastCommand(); 
    }

    private void OnDisable()
    {
        input.Player.Next.performed -= ctx => PlaceMarker();
        input.Player.Previous.performed -= ctx => CommandInvoker.Instance.UndoLastCommand(); 
        input.Disable();
    }

    private void PlaceMarker()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector2 worldPos = cam.ScreenToWorldPoint(mouseScreenPos);

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null)
        {
            ICommand placeCommand = new CommandPattern(objectPrefab, hit.point);
            CommandInvoker.Instance.ExecuteCommand(placeCommand);
        }
    }

}
