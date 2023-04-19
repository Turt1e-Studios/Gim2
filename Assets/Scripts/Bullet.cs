using UnityEngine;

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
            TestEnemy testEnemyScript = other.transform.parent?.gameObject.GetComponent<TestEnemy>();
            if (testEnemyScript != null)
            {
                testEnemyScript.ChangeHealth(-damage);
                testEnemyScript.ActivateExplosion();
            }
            return;
        }
        
        if (other.CompareTag("microwave_enemy"))
        {
            _audioSource.PlayOneShot(bulletHitSound);
            MicrowaveEnemy microwaveEnemyScript = other.gameObject.GetComponent<MicrowaveEnemy>();

            microwaveEnemyScript.ChangeHealth(-damage);
            microwaveEnemyScript.ActivateExplosion();
            Destroy(gameObject);
        }
        
        // Destroy the bullet if it collides with the environment
        else if (!other.gameObject.CompareTag("Player"))
        {
            //bulletParticles.Play();
            Destroy(gameObject);
        }
    }
}