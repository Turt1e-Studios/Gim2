using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     
    public int damage;
    //public Enemy enemyHealth;
    public GameObject otherBullet;
    
    void Start()
    {
        //GameObject theEnemy = GameObject.Find("Enemy.prefab");
        //enemyHealth = theEnemy.GetComponent<Enemy>();
       // enemy = GetComponent<Enemy>();
        //enemyHealth =GetComponent<Enemy>();
        
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
           
            other.GetComponent<Enemy>().changeHealth(-1);
 
            Destroy(otherBullet);
           
            
            
        }

    }

}
