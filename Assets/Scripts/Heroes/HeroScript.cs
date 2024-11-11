using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public Hero heroData;
    public List<GameObject> barSpots = new List<GameObject>();
    private bool foundSpot;
    public Transform spotToGo;
    public Transform MissionStation;
    public int spotIndex;
    public float moveSpeed;


    public void EnterBar()
    {
        for(var i = 0; i < barSpots.Count; i++)
        {
            if(!foundSpot)
            {
                var taken = barSpots[i].GetComponent<SpotScript>().taken;

                if(!taken)
                {
                    spotToGo = barSpots[i].transform;
                    spotIndex = i;
                    foundSpot = true;
                    barSpots[i].GetComponent<SpotScript>().TakeSpot();
                }
            }
            
        }
    }

    void Awake()
    {
        barSpots = EventHandler.Instance.heroSpots;
        MissionStation = EventHandler.Instance.outStation;

        heroData = (Hero)ScriptableObject.CreateInstance(typeof(Hero));
        heroData.RandomizeValues();
        heroData.currentWeapon = (Weapons)EventHandler.Instance.nullWeapon;

        EnterBar();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, spotToGo.transform.position, moveSpeed*Time.deltaTime);
    }

    public void Click()
    {
        if(EventHandler.Instance.selected != null)
        {
            if(EventHandler.Instance.selected.GetComponent<QuestAssignScript>() != null)
                EvaluateQuest(EventHandler.Instance.selected.GetComponent<QuestAssignScript>().quest);
        }
    }

    private void EvaluateQuest(QuestData quest)
    {
        if(heroData.DecideToTakeMission(quest))
            AcceptQuest();
    }

    public void AcceptQuest()
    {
        LeaveSpot();
        EventHandler.Instance.selected.SendMessage("HeroAssigned", gameObject);
    }

    public void RecieveItems(List<Item> missionRewards)
    {
        heroData.RecieveItems(missionRewards);
    }

    public void LeaveSpot()
    {
        spotToGo=MissionStation;
        barSpots[spotIndex].GetComponent<SpotScript>().LeaveSpot();
        foundSpot=false;
    }
}

