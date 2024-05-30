using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemScript : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    
    GameObject TopUi;
    private bool isBeingDragged = false;
    public GameObject startPos;
    [SerializeField] float snapDist;

    void Awake()
    {
        TopUi = ScreenCalculations.TopUI();
    }

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

        for(int i = 0; i < EventHandler.Instance.openQuests.Count; i++)
        {
            var quest = EventHandler.Instance.openQuests[i];
            if(Vector2.Distance(transform.position, quest.transform.position) <= snapDist)
            {
                transform.position = quest.transform.position;
                transform.SetParent(quest.transform);
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isBeingDragged = true;
        transform.SetParent(TopUi.transform);
    }
}
