using UnityEngine;

// This class is the base Enemy class that other Enemies derive from.

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject deathItem;
    [SerializeField] protected int maxHealth;
    protected int health;

    // To be overriden in each enemy scripts. For example, if an enemy explodes when it dies.
    protected virtual void OnDeath()
    {
        var transform1 = transform;
        Instantiate(deathItem, transform1.position + new Vector3(0, 1, 0), transform1.rotation);
        Destroy(gameObject);
    }

    // Changes the health of the enemy, and is destroyed upon death.
    public void ChangeHealth(int change)
    {
        Debug.Log(health);
        health += change;
    
        if (health > 0) return;
        Debug.Log("health: " + health);
        OnDeath();
    }
}

