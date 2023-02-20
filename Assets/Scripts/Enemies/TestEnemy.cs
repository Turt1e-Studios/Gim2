using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    // Note to whoever's editing this code: you don't need to add a health variable here because this class inherits from Enemy which already has health functionality.
    [SerializeField] int speed = 1;
    GameObject player;
    private Player playerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; // have to include this line to set health in any enemy class
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position , speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            playerScript.ChangeHealth(-1);
        }
    }
}
