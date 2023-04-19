using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void CheckItems(int level)
    {
        if (level == 1)
        {
            int count = 0;
            foreach (Item item in items)
            {
                if (item.name == "Metal Filings")
                {
                    count++;
                }
            }

            if (count >= 5)
            {
                NextLevel();
            }
        }
    
        // circuit core, iron plank
        if (level == 2)
        {
            int metalCount = 0;
            int plankCount = 0;

            foreach (Item item in items)
            {
                if (item.name == "Metal Filings")
                {
                    metalCount++;
                }
                else if (item.name == "Iron Plank")
                {
                    plankCount++;
                }
            }

            if (metalCount >= 10 && plankCount >= 5)
            {
                NextLevel();
            }
        }

        if (level == 3)
        {
            int metalCount = 0;
            int plankCount = 0;
            int coreCount = 0;

            foreach (Item item in items)
            {
                if (item.name == "Metal Filings")
                {
                    metalCount++;
                }
                else if (item.name == "Iron Plank")
                {
                    plankCount++;
                }
                else if (item.name == "Circuit Core")
                {
                    coreCount++;
                }
            }

            if (metalCount >= 5 && plankCount >= 5 && coreCount >= 5)
            {
                NextLevel();
            }
        }
    }

    private void NextLevel()
    {
        // Add a check if it isn't the last scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
