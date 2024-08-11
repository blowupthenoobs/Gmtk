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
    public Item sword;
    // public Item healthPotion;

    public GameObject defaultQuest;

    public List<GameObject> openQuests = new List<GameObject>();


    public GameObject selected;

    void Awake()
    {
        if(Instance==null)
            Instance=this;
        else
            Destroy(gameObject);

        //Starting Items
        inventory.GetComponent<InventoryScript>().RecieveItem(sword, 2);
        // inventory.GetComponent<InventoryScript>().recieveItem(healthPotion, 1);
        StartCoroutine(WaitToMakeHero(2));
        questContainer.GetComponent<QuestInventoryScript>().RecieveQuest(defaultQuest);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var originalSelection = selected;

            float timer = Time.time + 1;

            while(timer < Time.time)
                Debug.Log("waiting");
            
            // if(originalSelection == selected)
            //     selected = null;
        }
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

    public void SendInventoryMessage(string command, Item item)
    {
        //figure out how to put functions here
    }
}
