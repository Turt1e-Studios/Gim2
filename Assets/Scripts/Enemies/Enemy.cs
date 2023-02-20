using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int health;

    // to be overriden in each enemy scripts. For example, if an enemy explodes when it dies.
    protected virtual void OnDeath()
    {
        
    }

    // Changes the health of the enemy, and is destroyed upon death.
    public void ChangeHealth(int change)
    {
        Debug.Log(health);
        health += change;
        if (health <= 0)
        {
            OnDeath();
            print("health: " + health);
            Destroy(gameObject);
        }
    }
}
