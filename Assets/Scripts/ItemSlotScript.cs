using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotScript : MonoBehaviour
{
    public GameObject inventory;
    public GameObject placeHolder;
    public GameObject heldItem;
    private GameObject item;
    public bool hasItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void VisualizeItem(GameObject newItem)
    {
        Debug.Log("somethingHappened");
        
        hasItem=true;
        heldItem=newItem;
        item=Instantiate(heldItem, gameObject.transform.position, gameObject.transform.rotation);
        item.transform.SetParent(gameObject.transform);
    }

    public void RemoveItem()
    {
        Destroy(item);
        heldItem=placeHolder;
        hasItem=false;
    }

    public void Select()
    {
        Debug.Log(inventory.GetComponent<InventoryScript>().checkItemCount(heldItem));
    }
}
