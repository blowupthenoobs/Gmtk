using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiMoveScript : MonoBehaviour
{
    public GameObject tab;
    private bool vert;
    private float moveDistance;
    private bool up;
    public Vector2 startPos;
    private Vector2 altPos;

    void Awake()
    {
        vert=tab.GetComponent<PopUpScript>().vert;
        moveDistance=tab.GetComponent<PopUpScript>().moveDistance;

        if(vert)
            altPos = new Vector2(startPos.x, startPos.y + moveDistance);
        else
            altPos = new Vector2(startPos.x + moveDistance, startPos.y);
    }

    public void Move(){

        if(vert)
        {
            if(up)
            {
                transform.position=new Vector2(tab.transform.position.x, tab.transform.position.y - moveDistance);
                up=false;
            }
            else
            {
                transform.position = new Vector2(tab.transform.position.x, tab.transform.position.y+moveDistance);
                up=true;
            }
        }
        
    }

    public bool isUp()
    {
        return up;
    }


}
