using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("mat"))
        {
            other.gameObject.GetComponent<ItemPickup>().Interact();
        }
        else if (other.gameObject.CompareTag("end"))
        {
            CheckIfNextLevel();
        }
    }

    // This should definitely not be in this class. I'm too tired to do anything at this point
    private void CheckIfNextLevel()
    {
        Inventory.instance.CheckItems(SceneManager.GetActiveScene().buildIndex);
    }
}
