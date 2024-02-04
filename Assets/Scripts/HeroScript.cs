using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public List<GameObject> barSpots = new List<GameObject>();
    private bool foundSpot;
    public Transform spotToGo;
    public Transform MissionStation;
    public int spotIndex;
    public float moveSpeed;

    public bool foundFirstSpot;

    public void EnterBar()
    {
        transform.position=Vector2.MoveTowards(transform.position, spotToGo.transform.position, moveSpeed*Time.deltaTime);
      

        Debug.Log(barSpots.Count);
        for(var i=0;i>barSpots.Count;i++)
        {
                Debug.Log("running loop");
            if(!foundSpot)
            {
                var taken=barSpots[i].GetComponent<SpotScript>().taken;

                if(!taken){
                    if(!foundSpot)
                    {
                        spotToGo=barSpots[i].transform;
                        spotIndex=i;
                        foundSpot=true;
                        barSpots[i].GetComponent<SpotScript>().TakeSpot();
                    }
                    
                }
            }
            
        }
    }

    void Awake()
    {
        barSpots = EventHandler.Instance.heroSpots;
        MissionStation = EventHandler.Instance.outStation;
        foundFirstSpot = false;
    }

    void Update()
    {
        spotToGo=barSpots[spotIndex].transform;
        if(!foundFirstSpot)
        {
            EnterBar();
            foundFirstSpot=true;
        }

            transform.position = Vector2.MoveTowards(transform.position, spotToGo.transform.position, moveSpeed*Time.deltaTime);
    }

    public void LeaveSpot()
    {
        spotToGo=MissionStation;
        barSpots[spotIndex].GetComponent<SpotScript>().LeaveSpot();
        foundSpot=false;
    }
}

