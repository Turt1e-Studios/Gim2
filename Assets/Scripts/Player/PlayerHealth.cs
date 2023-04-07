using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioSource playerHitSound;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private GameOverScreen gameOverScreen;
    [SerializeField] private int maxHealth = 10;

    private int _health;
    
    private void Awake()
    {
        _health = maxHealth;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    // Public method, allows other classes to change the player's health.
    public void ChangeHealth(int change)
    {
        playerHitSound.Play();
        _health += change;
        healthBar.SetHealth(_health);
        if (_health < 0)
        {
            gameOverScreen.GameOver();
        }
    }
}
