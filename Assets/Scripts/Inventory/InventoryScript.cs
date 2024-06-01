using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] List<GameObject> itemSlots = new List<GameObject>();
    public List<object> inventoryItems = new List<object>(); //evens store the gameobject (item), odds store the amount of said (previous) item


    public void recieveItem(Item item, int count)
    {
        if (inventoryItems.Contains(item))
        {
            int indexOfItemCount = inventoryItems.IndexOf(item) + 1;

            inventoryItems[indexOfItemCount] = (int)inventoryItems[indexOfItemCount] + count;
        }
        else
        {
            inventoryItems.Add(item);
            inventoryItems.Add(count);
            AssignItem(item);
        }
    }
    
    public bool loseItem(Item item, int count)
    {

        int indexOfItemCount = inventoryItems.IndexOf(item) + 1;

        

        if ((int)inventoryItems[indexOfItemCount] <= count)
        {
            inventoryItems[indexOfItemCount] = (int)inventoryItems[indexOfItemCount] - count;

            if (((int)inventoryItems[indexOfItemCount] == 0))
            {
                inventoryItems.RemoveAt(indexOfItemCount);
                inventoryItems.RemoveAt(indexOfItemCount);
                LoseStack(item);
            }

            return true;
        }
        else
            return false;
    }

    public int checkItemCount(Item item)
    {
        int indexOfItemCount;

        indexOfItemCount = inventoryItems.IndexOf(item) + 1;

        return (int)inventoryItems[indexOfItemCount];
    }

    void Update()
    {

    }

    private void AssignItem(Item item)
    {
        bool foundSpot = false;

        for(var i=0; i<itemSlots.Count; i++)
        {
            if(!itemSlots[i].GetComponent<ItemSlotScript>().hasItem && !foundSpot)
            {
                itemSlots[i].GetComponent<ItemSlotScript>().VisualizeItem(item);
                foundSpot=true;
            }
        }
    }

    private void LoseStack(Item item)
    {
        for(var i=0; i<itemSlots.Count; i++)
        {
            if(itemSlots[i].GetComponent<ItemSlotScript>().heldItem = item)
                itemSlots[i].GetComponent<ItemSlotScript>().RemoveItem();
        }
    }

    public void AddSlot(GameObject slot)
    {
        itemSlots.Add(slot);
    }

    
}
