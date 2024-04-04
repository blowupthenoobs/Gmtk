using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static EventHandler Instance;

    public GameObject GameElementContainer;

    public GameObject hero;
    public GameObject inventory;
    public GameObject questContainer;
    public List<GameObject> heroSpots = new List<GameObject>();
    public Transform outStation;


    //Items
    public GameObject sword;
    public GameObject healthPotion;

    public GameObject defaultQuest;

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
        questContainer.GetComponent<QuestInventoryScript>().RecieveQuest(defaultQuest);
    }

    void Update()
    {
        
    }

    public void MakeHero()
    {
        GameObject Character = Instantiate(hero, outStation.position, Quaternion.Euler(0, 0, 0));
        Character.transform.SetParent(GameElementContainer.transform);
    }

    private IEnumerator WaitToMakeHero(int Time)
    {
        yield return new WaitForSeconds(Time);
        MakeHero();
    }
}
