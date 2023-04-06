using UnityEngine;

// The microwave enemy.
public class MicrowaveEnemy : Enemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxHeight = 10f;
    [SerializeField] private float secondsPerShot = 3f;
    [SerializeField] private float bulletSpeed = 20f;

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
        if (transform.position.y <= maxHeight)
        {
            transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }
        else if (!isShooting)
        {
            isShooting = true;
            InvokeRepeating(nameof(Shoot), 0f, secondsPerShot);
        }
        transform.LookAt(player.transform);
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, _transform.position, _transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed; 
    }
}

