using UnityEngine;

// Just bullet that damages the player I thinK?

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("enemy")) return;
        
        other.GetComponent<Enemy>().ChangeHealth(-damage);
        Destroy(gameObject);
    }
}
