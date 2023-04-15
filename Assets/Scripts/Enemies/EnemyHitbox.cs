using System;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.Find("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().ChangeHealth(-1);
        }
    }
}
