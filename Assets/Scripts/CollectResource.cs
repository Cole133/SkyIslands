using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CollectResource : MonoBehaviour
{
    public Inventory playerInventory;

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if(hit.collider != null)
            {
                ResourceNode resourceNode = hit.collider.GetComponent<ResourceNode>();
                if(resourceNode != null)
                {
                    resourceNode.Harvest(playerInventory);
                }
            }
        }
    }
}
