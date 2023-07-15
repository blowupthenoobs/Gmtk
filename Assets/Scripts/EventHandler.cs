using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public GameObject hero;
    public GameObject inventory;
    public GameObject[] heroSpots;
    public Transform outStation;


    //Items
    public GameObject sword;

    void Awake()
    {
        inventory.GetComponent<InventoryScript>().recieveItem(sword, 1, false);
        StartCoroutine(WaitToMakeHero(2));
    }

    void Update()
    {
        
    }

    public void MakeHero()
    {
        GameObject Character = Instantiate(hero, outStation.position, Quaternion.Euler(0, 0, 0));
        for(var i=0;i<heroSpots.Length;i++){
            Character.GetComponent<HeroScript>().barSpots[i] = heroSpots[i];
        }
        Character.GetComponent<HeroScript>().MissionStation=outStation;

        Character.GetComponent<HeroScript>().foundFirstSpot=false;
    }

    private IEnumerator WaitToMakeHero(int Time)
    {
        MakeHero();
        yield return new WaitForSeconds(Time);
    }
}
