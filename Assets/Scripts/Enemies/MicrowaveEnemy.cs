using UnityEngine;

// The microwave enemy.
public class MicrowaveEnemy : Enemy
{
    [SerializeField] private int speed = 10;
    private Vector3 _direction;
    private const float TimeBetweenChanges = 5;
    private float _lastStop;

    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
        _direction = Random.insideUnitSphere;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time - _lastStop < TimeBetweenChanges)
        {
            transform.Translate(_direction * (Time.deltaTime * speed));
        }
        else
        {
            _direction = Random.insideUnitSphere;
            _lastStop = Time.time;
        }
    }
}

