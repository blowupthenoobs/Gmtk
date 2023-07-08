using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public GameObject hero;

    void Awake()
    {
        Instantiate(hero, new Vector3(7, -1, 0), Quaternion.Euler(0, 0, 0));
    }

    void Update()
    {
        
    }
}
