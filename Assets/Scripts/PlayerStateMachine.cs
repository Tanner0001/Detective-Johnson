using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementStateMachine : MonoBehaviour
{
    public float moveSpeed = 3.5f;

    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 moveInput;
    private Vector2 lastMoveDirection = Vector2.down;

    private PlayerInputActions.PlayerInputActions inputActions;

    private enum PlayerState
    {
        Idle,
        Walking
    }

    private PlayerState currentState;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inputActions = new PlayerInputActions.PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Disable();
    }

    void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void Update()
    {
        // Choose state
        if (moveInput != Vector2.zero)
        {
            currentState = PlayerState.Walking;
            lastMoveDirection = moveInput;
        }
        else
        {
            currentState = PlayerState.Idle;
        }

        UpdateAnimation();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput.normalized * moveSpeed;
    }

    void UpdateAnimation()
    {
        string direction;
        if (Mathf.Abs(lastMoveDirection.x) > Mathf.Abs(lastMoveDirection.y))
        {
            direction = lastMoveDirection.x > 0 ? "Right" : "Left";
        }
        else
        {
            direction = lastMoveDirection.y > 0 ? "Up" : "Down";
        }

        string animName = (currentState == PlayerState.Walking ? "Walk_" : "Idle_") + direction;
        animator.Play(animName);
    }
}
