using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    

    [SerializeField] int speed = 1;
    GameObject player;
    
    private Player playerScript;
    public float enemyLife = 3;
    

    //public GameObject this;

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

    public void EnemyHealth(int change)
    {
        enemyLife += change;
        if (enemyLife <= 0)
        {
            print("This part works");
            Destroy(this.gameObject);
        } 
    }
}
