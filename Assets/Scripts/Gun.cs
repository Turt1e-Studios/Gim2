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
        if (Input.GetMouseButtonDown(0) && playerScript.fightingAction == Shoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        gunfireAudio.Play();
        if (Time.time - lastShot < cooldown)
        {
            return;
        }
        lastShot = Time.time;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * speed; 
    }
}
