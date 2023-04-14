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
        // Enemy loses health when colliding with the bullet
        if (other.gameObject.CompareTag("enemy"))
        {
            _audioSource.PlayOneShot(bulletHitSound);
            other.GetComponent<Enemy>().ChangeHealth(-damage);
        }
        
        // Destroy the bullet if it collides with the environment
        else if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("microwave_enemy"))
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
