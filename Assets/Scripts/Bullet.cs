using System;
using UnityEngine;

// Just bullet that damages the player I thinK?

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter(Collider other)
    {
        // Enemy loses health when colliding with the bullet
        if (other.gameObject.CompareTag("enemy"))
        {
            other.GetComponent<Enemy>().ChangeHealth(-damage);
        }

        // Destroy the bullet if it collides with something
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Probably could also implement this for x and z directions too. Not sure how to do this while still being performant
        if (transform.position.y < -Settings.outOfBoundsBox)
        {
            Destroy(gameObject);
        }
    }
}
