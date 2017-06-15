using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];            // The collection that store the inventory's item images.
    public Image[] selectedImages = new Image[numItemSlots];        // The collection that stores each item slot's image idicating selection.
    public Item[] items = new Item[numItemSlots];                   // The collection that stores the inventory's items.
    public const int numItemSlots = 4;                              // The maximum number of items the inventory can store.

    public int selectedItemIndex = 0;                              // Index for the selected item.

    /* Add an item to the inventory.
     * Returns true if the item is successfully added. */
    public bool AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; ++i)
        {
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return true;
            }
        }
        return false;
    }

    /* Removes an item from the inventory. */
    public void RemoveItem(Item itemToRemove, int index = -1)
    {
        for (int i = 0; i < items.Length; ++i)
        {
            if (items[i] == itemToRemove)
            {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
                return;
            }
        }
    }

    /* Changes the currently selected item. */
    public void ChangeSelectedItem(bool increment)
    {
        selectedImages[selectedItemIndex].enabled = false;
        if (increment)
        {
            if (selectedItemIndex < (numItemSlots - 1))
            {
                selectedItemIndex++;
            }
            else
            {
                selectedItemIndex = 0;
            }
        }
        else
        {
            if (selectedItemIndex > 0)
            {
                selectedItemIndex--;
            }
            else
            {
                selectedItemIndex = numItemSlots - 1;
            }
        }
        selectedImages[selectedItemIndex].enabled = true;
    }
}