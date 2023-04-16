using System;
using UnityEngine;

// "Box" placeholder enemy

public class TestEnemy : Enemy
{
    // Note to whoever's editing this code: you don't need to add a health variable here because this class inherits from Enemy which already has health functionality.
    [SerializeField] private int speed = 1;
    [SerializeField] private float distanceFromPlayer = 5f;
    [SerializeField] private GameObject particleObject;
    [SerializeField] private GameObject explosionObject;
    private GameObject player;
    private Player playerScript;
    private PlayerHealth playerHealthScript;
    private Rigidbody testEnemyRb;
    private ParticleSystem enemyParticles;
    private ParticleSystem explosionParticles;

    private void Awake()
    {
        health = maxHealth; // have to include this line to set health in any enemy class
        testEnemyRb = GetComponent<Rigidbody>();
        enemyParticles = particleObject.GetComponent<ParticleSystem>();
        explosionParticles = explosionObject.GetComponent<ParticleSystem>();
        explosionParticles.Stop();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) > distanceFromPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        enemyParticles.Play();
        if (!enemyParticles.isPlaying)
        {
            enemyParticles.Play();
        }
    }

    private void OnEnable()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
        playerHealthScript = player.GetComponent<PlayerHealth>();
        playerScript.OnKick += GetKicked;
    }

    private void OnDisable()
    {
        if (player != null)
        {
            playerScript = player.GetComponent<Player>();
            playerHealthScript = player.GetComponent<PlayerHealth>();
            playerScript.OnKick -= GetKicked;
        }
    }

    // Apply a force in the opposite direction of the player
    private void GetKicked(object sender, Player.KickEventArgs kickEventArgs)
    {
        if (Vector3.Distance(transform.position, player.transform.position) > kickEventArgs.kickRange) return;
    
        Vector3 forceDirection = (transform.position  - player.transform.position).normalized;
        testEnemyRb.AddForce (forceDirection * kickEventArgs.kickStrength, ForceMode.Impulse);
    }

    public void ActivateExplosion()
    {
        explosionParticles.Play();
    }
}

