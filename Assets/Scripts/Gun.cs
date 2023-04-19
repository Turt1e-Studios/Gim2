using UnityEngine;

/*
 * Gun that shoots
 */

public class Gun : MonoBehaviour
{
    // Starts with a cooldown

    [SerializeField] private AudioSource gunfireAudio;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float cooldown;
    [SerializeField] private float speed = 10;
    private float lastShot;
    private Player playerScript;

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        playerScript.fightingAction = Shoot;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Instantiate the bullet
            GameObject bullet = Instantiate(bulletPrefab) as GameObject;

            // Set the position of the bullet to the position of the camera
            bullet.transform.position = firePoint.transform.position;

            // Set the velocity of the bullet to the direction that the camera is facing
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = Camera.main.transform.forward* 40; // Change 40 to whatever speed you want the bullet to travel at
        }
    }
private void Shoot()
    {
        if (Time.time - lastShot < cooldown)
        {
            return;
        }
        gunfireAudio.Play();
        lastShot = Time.time;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //bullet.GetComponent<Bullet>().Source = gameObject;
        bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * speed; 
    }
}
