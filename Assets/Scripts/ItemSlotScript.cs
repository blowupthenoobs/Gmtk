using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotScript : MonoBehaviour
{
    public GameObject inventory;
    public GameObject sword;
    public GameObject item;
    public bool hasItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        Debug.Log(inventory.GetComponent<InventoryScript>().checkItemCount(sword));
    }

    private void Update()
    {
        if(inventory.GetComponent<InventoryScript>().checkItemCount(sword)>0)
        {
            if(!hasItem)
            {
                item=Instantiate(sword, gameObject.transform.position, gameObject.transform.rotation);
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
