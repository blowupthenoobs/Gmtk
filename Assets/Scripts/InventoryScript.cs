using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
        public int maxItemCountIncluding0;
        public GameObject[] itemSlots;

    List<object> inventoryItems = new List<object>(); //evens store the gameobject (item), odds store the amount of said (previous) item

    public void recieveItem(GameObject item, int count, bool forceTransaction)
    {
        if (inventoryItems.Contains(item))
        {
            int indexOfItemCount; //the index of where the item count is stored for the specified item

            indexOfItemCount = inventoryItems.IndexOf(item) + 1;

            inventoryItems[indexOfItemCount] = (int)inventoryItems[indexOfItemCount] + count;
        }
        else
        {
            if (inventoryItems.Count / 2 >= maxItemCountIncluding0 && !forceTransaction)
            {
                //Max inventory reached!
                return;
            }
            inventoryItems.Insert(0, count); //count must go first because it is the 2nd item
            inventoryItems.Insert(0, item);
            AssignItem(item);
        }
    }
    
    public bool loseItem(GameObject item, int count, bool forceTransaction) //its a bool type so it can return true/false (has enough items)
    {
        int indexOfItemCount; //the index of where the item count is stored for the specified item

        indexOfItemCount = inventoryItems.IndexOf(item) + 1;

        inventoryItems[indexOfItemCount] = (int)inventoryItems[indexOfItemCount] - count;

        if ((int)inventoryItems[indexOfItemCount] < 0 && !forceTransaction) //checks if we have at least 0 items left
        {
            //refund items and return that we cannot afford it unless forceTransaction
            inventoryItems[indexOfItemCount] = (int)inventoryItems[indexOfItemCount] + count;

            return false;
        }
        else
        {
            if (((int)inventoryItems[indexOfItemCount] == 0))
            {
                //if we now have 0 of the item, simply remove the item from the list
                inventoryItems.Remove(item);
                LoseStack(item);
            }

            return true;
        }
    }

    public int checkItemCount(GameObject item)
    {
        int indexOfItemCount; //the index of where the item count is stored for the specified item

        indexOfItemCount = inventoryItems.IndexOf(item) + 1;

        return (int)inventoryItems[indexOfItemCount];
    }

    void Update()
    {

    }

    private void AssignItem(GameObject item)
    {
        Debug.Log("somethingHappened");
        for(var i=0; i<itemSlots.Length; i++)
        {
            if(!itemSlots[i].GetComponent<ItemSlotScript>().hasItem)
                itemSlots[i].GetComponent<ItemSlotScript>().VisualizeItem(item);
        }
    }

    private void LoseStack(GameObject item)
    {
        for(var i=0; i<itemSlots.Length; i++)
        {
            if(itemSlots[i].GetComponent<ItemSlotScript>().heldItem=item)
                itemSlots[i].GetComponent<ItemSlotScript>().RemoveItem();
        }
    }

    
}
