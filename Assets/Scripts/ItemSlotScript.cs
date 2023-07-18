using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotScript : MonoBehaviour
{
    public GameObject inventory;
    public GameObject heldItem;
    public GameObject item;
    public bool hasItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        Debug.Log(inventory.GetComponent<InventoryScript>().checkItemCount(heldItem));
    }

    void Update()
    {
        if(inventory.GetComponent<InventoryScript>().checkItemCount(heldItem)>0)
        {
            if(!hasItem)
            {
                item=Instantiate(heldItem, gameObject.transform.position, gameObject.transform.rotation);
                item.GetComponent<ItemScript>().Slot=gameObject;
                hasItem=true;
            }
            
        }
        else
        {
            hasItem=false;
        }
    }
}
