using UnityEngine;

// An Item that the player can pick up

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject
{
    public new string name = "New Item";
    public Sprite icon;
    public bool isDefaultItem;

    public virtual void Use()
    {
        // Use the item, something might happen
        Debug.Log("Using " + name);
    }
}
