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
    public AudioSource src;
    public AudioClip SFX_OPEN, SFX_CLOSE;

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
        if (vector.GetComponent<uiMoveScript>().isUp()){
            src.clip = SFX_CLOSE ;
        }else{
            src.clip = SFX_OPEN;
        }
        src.Play();

        
        vector.GetComponent<uiMoveScript>().Move();
            
       } 
}
