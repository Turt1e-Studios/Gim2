using System.Collections.Generic;
using UnityEngine;

// This class stores Items in an inventory system

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than once instance of Inventory found!");
            return;
        }
        instance = this;
    }

    #endregion

    // apparently calls methods attached when event happens or something
    // I think these variables might need to be public
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    public bool Add(Item item)
    {
        if (item.isDefaultItem) return true;
        if (items.Count >= space)
        {
            Debug.Log("Not enough room in Inventory.");
            return false;
        }
        items.Add(item);

        UICallback();
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        UICallback();
    }

    private void UICallback()
    {
        onItemChangedCallback?.Invoke();
    }
}
