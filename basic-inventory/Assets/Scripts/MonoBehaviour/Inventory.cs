using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] itemImages = new Image[numItemSlots];            // The collection that store the inventory's item images.
    public Image[] selectedImages = new Image[numItemSlots];        // The collection that stores each item slot's image idicating selection.
    public Item[] items = new Item[numItemSlots];                   // The collection that stores the inventory's items.
    public Text[] itemCountText = new Text[numItemSlots];           // The collection that stores the count number for each item in the inventory.
    public const int numItemSlots = 4;                              // The maximum number of items the inventory can store.

    public int selectedItemIndex = 0;                              // Index for the selected item.

    /* Add an item to the inventory.
     * Returns true if the item is successfully added. */
    public bool AddItem(Item itemToAdd)
    {
        int itemDuplicateIndex = IsDuplicateItem(itemToAdd);
        if (itemDuplicateIndex > -1)
        {
            UpdateItemCount(itemDuplicateIndex, true);
            return true;
        }
        else
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
        }
        return false;
    }

    /* Removes an item from the inventory. */
    public void RemoveItem(Item itemToRemove)
    {
        for (int i = 0; i < items.Length; ++i)
        {
            if (items[i] == itemToRemove)
            {
                if (items[i].count > 1)
                {
                    UpdateItemCount(i, false);
                }
                else
                {
                    items[i] = null;
                    itemImages[i].sprite = null;
                    itemImages[i].enabled = false;
                    itemCountText[i].enabled = false;
                }
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

    /* Returns the index of the duplicate item in the inventory
     * or -1 if no duplicate exists. */
    private int IsDuplicateItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; ++i)
        {
            if (items[i] == itemToAdd)
            {
                return i;
            }
        }
        return -1;
    }

    /* Updates the item's count number. */
    private void UpdateItemCount(int itemIndex, bool increment)
    {
        if (increment)
        {
            items[itemIndex].count++;
        }
        else
        {
            items[itemIndex].count--;
        }

        if (items[itemIndex].count > 1)
        {
            itemCountText[itemIndex].text = "" + items[itemIndex].count;
            itemCountText[itemIndex].enabled = true;
        }
        else
        {
            itemCountText[itemIndex].enabled = false;
        }
    }
}