using UnityEngine;

// This class allows an Item to be picked up.

public class ItemPickup : Interactable
{
    public Item item;

    protected override void Interact()
    {
        base.Interact();

        PickUp();
    }

    private void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp) Destroy(gameObject);
    }
}
