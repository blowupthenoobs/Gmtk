using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiMoveScript : MonoBehaviour
{
    public GameObject tab;
    private bool up;


    public void Move(){
        var moveDistance=tab.GetComponent<PopUpScript>().moveDistance;
        var vert=tab.GetComponent<PopUpScript>().vert;

        if(vert)
        {
            if(up)
            {
                transform.position=new Vector2(tab.transform.position.x, tab.transform.position.y-moveDistance);
                up=false;
            }
            else
            {
                transform.position=new Vector2(tab.transform.position.x, tab.transform.position.y+moveDistance);
                up=true;
            }
        }
        
    }

    public bool isUp()
    {
        return up;
    }


}
