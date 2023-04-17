using UnityEngine;

// The microwave enemy.
public class MicrowaveEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxHeight = 10f;
    [SerializeField] private float secondsPerShot = 3f;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] private float damping = 1f;

    private GameObject player;
    private Transform _transform;
    private bool isShooting;

    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
        player = GameObject.Find("Player");
        _transform = transform;
    }

    // Update is called once per frame
    private void Update()
    {
        // Makes the microwave rise into the air
        if (transform.position.y <= maxHeight)
        {
            transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }
        // Shoot stuff
        else if (!isShooting)
        {
            isShooting = true;
            InvokeRepeating(nameof(Shoot), 0f, secondsPerShot);
        }
        
        var lookPos = player.transform.position - transform.position;
        lookPos.y = 0;
        lookPos.z = 0; // remove this line if you don't like how it rotates
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, _transform.position, _transform.rotation);
        bullet.GetComponent<Bullet>().Source = gameObject;
        bullet.GetComponent<Rigidbody>().velocity = (player.transform.position - transform.position) * bulletSpeed; 
    }
}

