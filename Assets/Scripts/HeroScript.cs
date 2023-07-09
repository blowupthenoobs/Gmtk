using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public GameObject[] barSpots;
    private bool foundSpot;
    private Transform spotToGo;
    public Transform MissionStation;
    public int spotIndex;
    public float moveSpeed;

    public void EnterBar()
    {
        Debug.Log("finding Spot");

        for(var i=0;i>barSpots.Length;i++)
        {
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
        EnterBar();
    }

    void Update()
    {
        if(foundSpot)
        {
            transform.position=Vector2.MoveTowards(transform.position, spotToGo.transform.position, moveSpeed*Time.deltaTime);
        }
    }

    public void LeaveSpot()
    {
        spotToGo=MissionStation;
        barSpots[spotIndex].GetComponent<SpotScript>().LeaveSpot();
        foundSpot=false;
    }
}
