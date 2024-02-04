using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static EventHandler Instance;

    public GameObject hero;
    public GameObject inventory;
    public List<GameObject> heroSpots = new List<GameObject>();
    public Transform outStation;


    //Items
    public GameObject sword;
    public GameObject healthPotion;

    void Awake()
    {
        if(Instance==null)
            Instance=this;
        else
            Destroy(gameObject);

        //Starting Items
        inventory.GetComponent<InventoryScript>().recieveItem(sword, 2);
        inventory.GetComponent<InventoryScript>().recieveItem(healthPotion, 1);
        StartCoroutine(WaitToMakeHero(2));
    }

    void Update()
    {
        
    }

    public void MakeHero()
    {
        GameObject Character = Instantiate(hero, outStation.position, Quaternion.Euler(0, 0, 0));
    }

    private IEnumerator WaitToMakeHero(int Time)
    {
        MakeHero();
        yield return new WaitForSeconds(Time);
    }
}
