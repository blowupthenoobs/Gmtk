using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] GameObject container;
    public bool vert;
    public float targetPos;
    private bool tabUp;
    public float moveDistance;
    public float moveSpeed;
    public AudioSource src;
    public AudioClip SFX_OPEN, SFX_CLOSE;

    private void Awake(){
        rb=GetComponent<Rigidbody2D>();
        tabUp = false;
    }

    void Update()
    {
        moveDistance = container.GetComponent<RectTransform>().localScale.y * container.GetComponent<RectTransform>().sizeDelta.y;

        if(vert)
        {
            if(tabUp)
                targetPos = moveDistance + gameObject.GetComponent<RectTransform>().localScale.y * gameObject.GetComponent<RectTransform>().sizeDelta.y;
            else
                targetPos = gameObject.GetComponent<RectTransform>().localScale.y * gameObject.GetComponent<RectTransform>().sizeDelta.y;
            Vector2 targetPosition = new Vector2(transform.position.x, targetPos);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
        
    }

    public void OnMouseUp()
    {
        tabUp = !tabUp;
        if (!tabUp)
            src.clip = SFX_CLOSE ;
        else
            src.clip = SFX_OPEN;
        
        src.Play();
    }
}
