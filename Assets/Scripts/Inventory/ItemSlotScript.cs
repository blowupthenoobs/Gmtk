using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotScript : MonoBehaviour
{
    public GameObject inventory;
    public GameObject placeHolder;
    public Item heldItem;
    private GameObject item;
    public bool hasItem;

    [SerializeField] GameObject itemPrefab;

    public void SetInventory(GameObject objectToBeSet)
    {
        inventory = objectToBeSet;
    }

    public void VisualizeItem(Item newItem)
    {
        hasItem = true;
        heldItem = newItem;
        item = Instantiate(itemPrefab, gameObject.transform.position, gameObject.transform.rotation);
        item.GetComponent<ItemScript>().AssignItem(newItem);
        item.GetComponent<ItemScript>().startPos = gameObject;
        item.transform.SetParent(gameObject.transform);
        item.transform.localScale *= ScreenCalculations.GetScale(item);
    }

    public void RemoveItem()
    {
        Destroy(item);
        heldItem = null;
        hasItem = false;
    }

    public void Select()
    {
        Debug.Log(inventory.GetComponent<InventoryScript>().checkItemCount(heldItem));
    }
}
