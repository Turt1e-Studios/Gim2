using UnityEngine;

/*
 * To be implemented
 */
public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // deactivate instead of destroying because object is being pooled
        other.gameObject.SetActive(false);
        Destroy(gameObject);
    }

}
