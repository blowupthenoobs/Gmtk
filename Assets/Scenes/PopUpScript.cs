using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool vert;
    public GameObject vector;
    private bool tabUp;
    public float moveDistance;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake(){
        rb=GetComponent<Rigidbody2D>();
        tabUp=false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position, vector.transform.position, moveSpeed*Time.deltaTime);
    }

    public void OnMouseUp(){
        
        vector.GetComponent<uiMoveScript>().Move();
            // if(tabUp){
            //         tabUp=false;
                    
            //         // transform.position-=(Vector3.up*moveSpeed);
            // }else{
            //         tabUp=true;
            //         transform.position=Vector2.MoveTowards(transform.position, vector.transform.position, moveSpeed*Time.deltaTime);
            //         // transform.position+=(Vector3.up*moveSpeed);
            // }
            
       } 
}
