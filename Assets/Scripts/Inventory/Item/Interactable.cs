using UnityEngine;

// Base interactable that player can interact with (pretty bad explanation but i kind of have no idea what this really does)

public class Interactable : MonoBehaviour
{
    [SerializeField] private float radius = 3f;

    private Transform player;
    private bool hasInteracted;
    // add InteractionTransform? [in Brackeys tutorial]

    protected virtual void Interact()
    {
        // this method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    // couldn't think of a better name for this, not a very descriptive method name tbh
    public void Touch (Transform playerTransform)
    {
        if (hasInteracted) return;
        player = playerTransform;
        float distance = Vector3.Distance(player.position, transform.position);
        
        if (!(distance <= radius)) return;
        Interact();
        hasInteracted = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

