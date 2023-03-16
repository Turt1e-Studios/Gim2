using UnityEngine;

// Updates the slot UI of inventory

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Transform itemsParent;
    [SerializeField] private GameObject inventoryUI;

    private Inventory inventory;
    private InventorySlot[] slots;

    // Start is called before the first frame update
    private void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Input.GetButtonDown("Inventory")) return;
        
        if (inventoryUI.activeSelf)
        {
            GeneralUI.DisableCursor();
        }
        else
        {
            GeneralUI.EnableCursor();
        }
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }

    private void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
