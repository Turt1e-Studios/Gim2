using UnityEngine;

// Just bullet that damages the player I thinK?

public class Bullet : MonoBehaviour
{
    [SerializeField] private AudioClip bulletHitSound;
    [SerializeField] private int damage;
    
    public GameObject Source { get; set; }

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Enemy loses health when colliding with the bullet
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.CompareTag("enemy"))
        {
            _audioSource.PlayOneShot(bulletHitSound);
            Debug.Log(other.transform.parent);
            // For some reason this causes an error but it still works so i'll just ignore it lol
            other.transform.parent.gameObject.GetComponent<TestEnemy>().ChangeHealth(-damage);
        }
        
        // Destroy the bullet if it collides with the environment
        else if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("microwave_enemy"))
        {
            Destroy(gameObject);
        }
        
        else if (other.gameObject.CompareTag("Player") && Source.gameObject.CompareTag("microwave_enemy"))
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().ChangeHealth(-1);
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
