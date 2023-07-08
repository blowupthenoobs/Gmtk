using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotScript : MonoBehaviour
{
    public GameObject inventory;
    public GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnMouseDown()
    {
        Debug.Log(inventory.GetComponent<InventoryScript>().checkItemCount(sword));
    }
}
