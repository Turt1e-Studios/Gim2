using UnityEngine;

// This class disables an object when it gets out of the top and bottom bounds.

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float topBound = 30;
    [SerializeField] private float lowerBound = -10;

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.z > topBound)
        {
            // Instead of destroying the projectile when it leaves the screen
            //Destroy(gameObject);

            // Just deactivate it
            gameObject.SetActive(false);
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
