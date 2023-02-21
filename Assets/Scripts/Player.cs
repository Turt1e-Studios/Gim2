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
    [SerializeField] float gravity;
    [SerializeField] int maxHealth = 10;
    [SerializeField] float speed = 6f;
    [SerializeField] float turnSmoothTime = 0.1f;
    
    CharacterController controller;
    float turnSmoothVelocity;
    int health;

    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // if hovering over UI, exit out before controlling player
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (controller.isGrounded)
        {
            gravity = 0;
            //print("It's grounded");
            //Vector3 move = new Vector3(0, -1, 0);
            //gameObject.transform.position += move;
        }

        else
        {
            gravity = -9.8f;
        }
        

        // Movement
        
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontalInput, gravity, verticalInput).normalized;
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            controller.Move(direction * Time.deltaTime * speed);
        }
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
        GameOverScreen.Setup();
    }
}

