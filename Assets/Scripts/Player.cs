using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    // ik this is a lot of [SerializeField]s lol
    [SerializeField] HealthBar healthBar;
    [SerializeField] GameOverScreen GameOverScreen;
    [SerializeField] Item item;
    [SerializeField] Transform cam;
    [SerializeField] Animator anim;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] int maxHealth = 10;
    [SerializeField] float speed = 6f;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] float jumpHeight = 3f;
    
    CharacterController controller;
    Vector3 velocity;
    float turnSmoothVelocity;
    int health;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        // make the cursor invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // if hovering over UI, exit out before controlling player
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // Movement

        // reset y velocity if grounded
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        
        // moving and turning
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle + gravity, 0f) * Vector3.forward;

            controller.Move(moveDir * Time.deltaTime * speed);
            anim.SetTrigger("Walking");
        }
        
        // jumping and gravity (from Brackeys first person movement tutorial)
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void ChangeHealth(int change)
    {
        health += change;
        healthBar.SetHealth(health);
        if (health < 0)
        {
            GameOver();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Interactable interactable = collision.gameObject.GetComponent<Interactable>();
        if (interactable != null)
        {
            interactable.Touch(transform);
        }
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameOverScreen.Setup();
    }
}

