using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemScript : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    
    GameObject TopUi;
    [SerializeField] Item item;
    private bool isBeingDragged = false;
    public GameObject startPos;
    [SerializeField] float snapDist;

    void Awake()
    {
        TopUi = ScreenCalculations.TopUI();

        // transform.localScale = new Vector3(1f, 1f);
    }

    public void AssignItem(Item source)
    {
        item = source;
        item.SetUpItem(gameObject);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isBeingDragged = false;

        if(Vector2.Distance(transform.position, startPos.transform.position) <= snapDist)
            ResetPosition();

        for(int i = 0; i < EventHandler.Instance.openQuests.Count; i++)
        {
            var quest = EventHandler.Instance.openQuests[i];
            if(Vector2.Distance(transform.position, quest.transform.position) <= snapDist)
            {
                transform.position = quest.transform.position;
                quest.SendMessage("AddItem", item);
                ResetPosition();
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isBeingDragged = true;
        transform.SetParent(TopUi.transform);
    }

    public void ResetPosition()
    {
        transform.position = startPos.transform.position;
        transform.SetParent(startPos.transform);
    }
}
