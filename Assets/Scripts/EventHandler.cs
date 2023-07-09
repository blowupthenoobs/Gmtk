using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public GameObject hero;
    public GameObject inventory;
    public Transform[] heroSpots;
    public Transform outStation;


    //Items
    public GameObject sword;

    void Awake()
    {
        inventory.GetComponent<InventoryScript>().recieveItem(sword, 1, false);
        StartCoroutine(WaitToMakeHero(5));
    }

    void Update()
    {
        
    }

    public void MakeHero()
    {
        GameObject Character = Instantiate(hero, new Vector3(7, -1, 0), Quaternion.Euler(0, 0, 0));
        for(i=0;i>heroSpots[].length;i++);
        {
            Character.GetComponent<HeroScript>().barSpots[i]=heroSpots[i];
        }
        Character.GetComponent<HeroScript>().MissionStation=outStation;
    }

    private IEnumerator WaitToMakeHero(int Time)
    {
        yield return new WaitForSeconds(Time);
        MakeHero();
    }
}
