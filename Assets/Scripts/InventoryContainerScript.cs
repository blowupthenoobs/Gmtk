using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainerScript : MonoBehaviour
{
    public GameObject tab;
    private float moveSpeed;
    public GameObject vector;
    private bool vert;

    void Awake()
    {
        vert=tab.GetComponent<PopUpScript>().vert;
        moveSpeed=tab.GetComponent<PopUpScript>().moveSpeed;
    }
    void Update()
    {
        if(vert)
        {
            Vector2 targetPosition = new Vector2(transform.position.x, vector.transform.position.y);
            transform.position=Vector2.MoveTowards(transform.position, targetPosition, moveSpeed*Time.deltaTime);
        }
    }
}
