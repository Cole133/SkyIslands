using UnityEngine;

public class ResourceNode : MonoBehaviour
{
    public Item dropItem;
    public Item dropItem2;
    public int dropAmount = 1;

    public void Harvest(Inventory inventory)
    {
        inventory.AddItem(dropItem, dropAmount);
        inventory.AddItem(dropItem2, dropAmount);
        Destroy(gameObject); // remove the resource after collecting
    }
}
