using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public Inventory playerInventory;
    public TextMeshProUGUI inventoryText;
    public GameObject inventoryPanel;

    public bool isOpen = false;

    private void Start()
    {
        inventoryPanel.SetActive(isOpen);
        inventoryText.text = "";
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
            inventoryPanel.SetActive(isOpen);
        }

        if (isOpen)
        {
            inventoryText.text = "Inventory:\n";
            foreach (var item in playerInventory.items)
            {
                inventoryText.text += $"{item.Key.itemName}: {item.Value}\n";
            }
        }
        else
        {
            inventoryText.text = "Inventory:\n";
        }

        
    }
}
