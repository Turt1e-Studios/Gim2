using System;
using UnityEngine;
using UnityEngine.EventSystems;

// Player: movement & health
public class Player : MonoBehaviour
{
    public Action fightingAction;
    public event EventHandler<KickEventArgs> OnKick; 
    public class KickEventArgs : EventArgs 
    { 
        public float kickStrength;
        public float kickRange;
    }
    
    // Delete this later as this is pretty bad programming practices.
    [Header("UI References")]
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private Item item;
    [SerializeField] private Transform cam;
    [SerializeField] private Animator anim;
    [Header("Movement Variables")]
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float jumpHeight = 3f;
    [Header("Ground Check")]
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f; // radius to check if grounded
    [Header("Combat Variables")] 
    [SerializeField] private float kickStrength = 1f;
    [SerializeField] private float kickRange = 5f;
    
    private static readonly int Walking = Animator.StringToHash("Walking"); 
    private CharacterController controller;
    private Vector3 velocity;
    private float turnSmoothVelocity;
    private int health;
    private bool _isGrounded;
    
    // Public method, allows other classes to change the player's health.
    public void ChangeHealth(int change)
    {
        health += change;
        healthBar.SetHealth(health);
        if (health < 0)
        {
            GameOver();
        }
    }

    private void Awake()
    {
        health = maxHealth;
        controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        // make the cursor invisible [actually, this should probably not be in the Player script.]
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        healthBar.SetMaxHealth(maxHealth);
        fightingAction = Kick;
    }

    // Update is called once per frame
    private void Update()
    {
        // if hovering over UI, exit out before controlling player
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // Movement
        CheckIfGrounded();
        RegularMovement();
        VerticalMovement();
        
        InvokeCombat();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Interactable interactable = collision.gameObject.GetComponent<Interactable>();
        if (interactable != null)
        {
            interactable.Touch(transform);
        }
    }

    private void InvokeCombat()
    {
        if (Input.GetMouseButtonDown(0))
        {
            fightingAction?.Invoke();
        }
    }

    private void CheckIfGrounded()
    {
        // Check if player is grounded from creating sphere from groundCheck, then reset velocity
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (_isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Buffer number to force player onto the ground (theoretically 0)
        }
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
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle + gravity, 0f) * Vector3.forward;

        controller.Move(moveDir * (Time.deltaTime * speed));
        anim.SetTrigger(Walking);
    }

    // Adds gravity and allows the player to jump. Maybe separate into 2 different methods.
    private void VerticalMovement()
    {
        // jumping and gravity (from Brackeys first person movement tutorial)
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        gameOverScreen.Setup();
    }

    private void Kick()
    {
        OnKick?.Invoke(this, new KickEventArgs{kickStrength = kickStrength, kickRange = kickRange});
    }
}

