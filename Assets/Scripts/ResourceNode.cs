using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    public Item dropItem;
    public int dropAmount = 1;

    public void Harvest(Inventory inventory)
    {
        inventory.AddItem(dropItem, dropAmount);
        Destroy(gameObject); // remove the resource after collecting
    }
}
