using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int health;

    // to be overriden in each enemy scripts
    protected virtual void OnDeath()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // when shot by player
    void changeHealth(int change)
    {
        health += change;
        if (health <= 0)
        {
            OnDeath();
        }
    }
}
