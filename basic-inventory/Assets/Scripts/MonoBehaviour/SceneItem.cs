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

    /* Simulates picking up the item. */
    public void PickupItem(Inventory playerInventory)
    {
        // Attempt to add the item data to your inventory.
        if (playerInventory.AddItem(itemData))
        {
            // Remove scene item.
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Inventory full.");
        }
    }
}