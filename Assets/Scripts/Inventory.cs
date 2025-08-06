using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Dictionary<Item, int> items = new Dictionary<Item, int>();

    public void AddItem(Item item, int amount)
    {
        if (items.ContainsKey(item))
        {
            items[item] += amount;
        }
        else
        {
            items[item] = amount;
        }

        Debug.Log($"Added {amount} {item.itemName} to inventory.");
    }

    public int GetItemCount(Item item)
    {
        return items.TryGetValue(item, out int count) ? count : 0;
    }
}
