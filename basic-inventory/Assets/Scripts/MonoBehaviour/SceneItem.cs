using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneItem : MonoBehaviour
{
    public Item itemData;                       // The data that represents this item.
    private float itemSpawnDistance = 3.0f;     // The distance the item will appear from the player when dropped.

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
    public void DropItem(Inventory playerInventory, Vector3 dropLocation, Vector3 forwardVector)
    {
        Vector3 dropPosition = dropLocation + (new Vector3(forwardVector.x, 0, forwardVector.z) * itemSpawnDistance);
        Instantiate(itemData.sceneObject, dropPosition, Quaternion.identity);
        playerInventory.RemoveItem(itemData);
    }
}