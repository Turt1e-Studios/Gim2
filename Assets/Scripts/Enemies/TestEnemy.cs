using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    [SerializeField] int speed = 3;
    GameObject player;
    Player playerScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("dudea");
        playerScript = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            playerScript.ChangeHealth(-1);
        }
    }
}
