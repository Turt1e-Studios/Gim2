using UnityEngine;

/*
 * Allows player to collect objects in inventory upon collision
 */
public class PlayerInteraction : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Interactable interactable = collision.gameObject.GetComponent<Interactable>();
        Debug.Log(interactable);
        if (interactable != null)
        {
            interactable.Touch(transform);
        }
    }
}
