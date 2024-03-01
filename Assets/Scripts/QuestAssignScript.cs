using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestAssignScript : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField] Canvas UI;
    [SerializeField] GameObject TopUi;
    private bool isBeingDragged = false;
    public GameObject startPos;
    public float snapDist;

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isBeingDragged = false;

        if(Vector2.Distance(transform.position, startPos.transform.position) <= snapDist)
        {
            transform.position = startPos.transform.position;
            transform.SetParent(startPos.transform);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isBeingDragged = true;
        transform.SetParent(TopUi.transform);
    }

    void Update()
    {

    }
}
