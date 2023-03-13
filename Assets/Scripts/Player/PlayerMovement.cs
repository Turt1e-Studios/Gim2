using UnityEngine;
using UnityEngine.EventSystems;

/*
 * Player movement script
 */

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float jumpHeight = 3f;
    [Header("Movement Animation")]
    [SerializeField] private Transform cam;
    [SerializeField] private Animator anim;
    [Header("Ground Check")]
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f; // radius to check if grounded
    
    private static readonly int Walking = Animator.StringToHash("Walking"); 
    private CharacterController _controller;
    private Vector3 _velocity;
    private float _turnSmoothVelocity;
    private bool _isGrounded;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if hovering over UI, exit out before controlling player
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        CheckIfGrounded();
        RegularMovement();
        VerticalMovement();
    }
    
    // Movement from Brackeys 3rd person movement tutorial
    private void RegularMovement()
    {
        // moving and turning
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (!(direction.magnitude >= 0.1f)) return;
        
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle + gravity, 0f) * Vector3.forward;

        _controller.Move(moveDir * (Time.deltaTime * speed));
        anim.SetTrigger(Walking);
    }

    // Adds gravity and allows the player to jump. Maybe separate into 2 different methods.
    private void VerticalMovement()
    {
        // jumping and gravity (from Brackeys first person movement tutorial)
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
    
    private void CheckIfGrounded()
    {
        // Check if player is grounded from creating sphere from groundCheck, then reset velocity
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f; // Buffer number to force player onto the ground (theoretically 0)
        }
    }
}
