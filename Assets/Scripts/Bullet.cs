using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
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
        if (other.gameObject.CompareTag("enemy"))
        {
            _audioSource.PlayOneShot(bulletHitSound);
            //bulletParticles.Play();
            Debug.Log(other.transform.parent);
            Debug.Log("Bullet collided with: " + other.tag);
            Debug.Log("Bullet collided with: " + other.gameObject.tag);
            // For some reason this causes an error but it still works so i'll just ignore it lol
            TestEnemy testEnemyScript = other.transform.parent?.gameObject.GetComponent<TestEnemy>();
            if (testEnemyScript != null)
            {
                testEnemyScript.ChangeHealth(-damage);
                testEnemyScript.ActivateExplosion();
            }
        }
        else if (other.gameObject.CompareTag("microwave_enemy") && !Source.gameObject.CompareTag("microwave_enemy"))
        {
            TestEnemy testEnemyScript = other.transform.parent.gameObject.GetComponent<TestEnemy>();

            testEnemyScript.ChangeHealth(-damage);
            testEnemyScript.ActivateExplosion();
            Destroy(gameObject);
        }
        // Destroy the bullet if it collides with the environment
        else if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("microwave_enemy"))
        {
            //bulletParticles.Play();
            Destroy(gameObject);
        }

        else if (other.gameObject.CompareTag("Player") && Source.gameObject.CompareTag("microwave_enemy"))
        {
            PlayerHealth playerHealth = GameObject.Find("Player")?.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.ChangeHealth(-1);
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        if (transform.position.y < -Settings.OutOfBoundsBox || transform.position.x < -Settings.OutOfBoundsBox || transform.position.z < -Settings.OutOfBoundsBox)
        {
            Destroy(gameObject);
        }
    }
}