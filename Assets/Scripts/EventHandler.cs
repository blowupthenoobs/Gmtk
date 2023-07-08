using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public GameObject hero;
    public GameObject inventory;


    //Items
    public GameObject sword;

    void Awake()
    {
        Instantiate(hero, new Vector3(7, -1, 0), Quaternion.Euler(0, 0, 0));
        inventory.GetComponent<InventoryScript>().recieveItem(sword, 1, false);
    }

    void Update()
    {
        
    }
}
