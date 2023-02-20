using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Note: SerializeField just means that the variable is editable in the Unity Inspector but not in other classes to prevent code accessing places that it shouldn't.
    // That means that you change the damage in the Prefab itself in the script component.
    [SerializeField] int damage;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            other.GetComponent<Enemy>().ChangeHealth(-damage);
            Destroy(gameObject);
        }
    }
}
