using System;
using UnityEngine;

// Just bullet that damages the player I thinK?

public class Bullet : MonoBehaviour
{
    [SerializeField] private AudioClip bulletHitSound;
    [SerializeField] private int damage;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Debug.Log("why tf isn't this working?????????????? AAAAAAAAAAAAAAAAAAAAAAAAAAA");
            _audioSource.PlayOneShot(bulletHitSound);
        }
        
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
        if (transform.position.y < -Settings.OutOfBoundsBox)
        {
            Destroy(gameObject);
        }
    }
}
