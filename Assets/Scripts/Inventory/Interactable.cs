using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    Transform player;
    bool hasInteracted = false;
    // add InteractionTransform? [in Brackeys tutorial]

    public virtual void Interact()
    {
        // this method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    // couldn't think of a better name for this, not a very descriptive method name tbh
    public void Touch (Transform playerTransform)
    {
        if (!hasInteracted)
        {
            player = playerTransform;
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
