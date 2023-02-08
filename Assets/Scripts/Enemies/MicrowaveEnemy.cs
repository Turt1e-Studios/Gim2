using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveEnemy : Enemy
{
    [SerializeField] int speed = 10;
    Vector3 direction;
    float timeBetweenChanges = 5;
    float lastStop;

    // Start is called before the first frame update
    void Start()
    {
        direction = Random.insideUnitSphere;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastStop < timeBetweenChanges)
        {
            transform.Translate(direction * Time.deltaTime * speed);
        }
        else
        {
            direction = Random.insideUnitSphere;
            lastStop = Time.time;
        }
    }
}
