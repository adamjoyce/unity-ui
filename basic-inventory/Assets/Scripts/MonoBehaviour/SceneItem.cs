using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItem : MonoBehaviour
{
    public Item itemData;                       // The data that represents this item.

    /* Use this for initialization. */
    void Start()
    {
        // Apply any item data changes...
    }

    /* Picks up this item in the scene. */
    public void PickupItem(Inventory playerInventory)
    {
        // Attempt to add the item data to your inventory.
        if (playerInventory.AddItem(itemData))
        {
            // Remove scene item.
            Destroy(gameObject);
        }
    }

    /* Generates this item to drop in the scene. */
    public void DropItem(Inventory playerInventory, Transform dropLocation)
    {
        Vector3 dropPosition = new Vector3(dropLocation.position.x, dropLocation.position.y, dropLocation.position.z + 5);
        Instantiate(itemData.sceneObject, dropPosition, Quaternion.identity);
        playerInventory.RemoveItem(itemData);
    }
}