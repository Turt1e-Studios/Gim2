using UnityEngine;

// This class is the base Enemy class that other Enemies derive from.

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int health;

    // To be overriden in each enemy scripts. For example, if an enemy explodes when it dies.
    protected virtual void OnDeath()
    {
    
    }

    // Changes the health of the enemy, and is destroyed upon death.
    public void ChangeHealth(int change)
    {
        Debug.Log(health);
        health += change;
    
        if (health > 0) return;
        OnDeath();
        Debug.Log("health: " + health);
        Destroy(gameObject);
    }
}

