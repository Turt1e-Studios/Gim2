using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = GameObject.Find("Player")?.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.ChangeHealth(-1);
                Destroy(gameObject);
            }
        }
        else if (!other.CompareTag("microwave_enemy"))
        {
            Destroy(gameObject);
        }
    }
}
