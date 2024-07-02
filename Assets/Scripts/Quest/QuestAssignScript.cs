using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestAssignScript : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    GameObject TopUi;
    private bool isBeingDragged = false;
    [SerializeField] GameObject startPos;
    [SerializeField] float snapDist;

    public List<Item> items = new List<Item>();

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
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isBeingDragged = true;
        transform.SetParent(TopUi.transform);

        if(!EventHandler.Instance.openQuests.Contains(gameObject))
            EventHandler.Instance.openQuests.Add(gameObject);
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        EventHandler.Instance.inventory.GetComponent<InventoryScript>().LoseItem(item, 1);
    }
}
