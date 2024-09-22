using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestAssignScript : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public QuestData quest;
    GameObject TopUi;
    private bool isBeingDragged = false;
    [SerializeField] GameObject startPos;
    [SerializeField] float snapDist;

    private bool canBeSelected = true;
    public List<Item> items = new List<Item>();

    void Awake()
    {
        TopUi = ScreenCalculations.TopUI();
    }

#region draggingStuffs

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isBeingDragged = false;

        if(Vector2.Distance(transform.position, startPos.transform.position) <= snapDist)
            ResetPosition();
        
        canBeSelected = true;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canBeSelected = false;
        isBeingDragged = true;
        transform.SetParent(TopUi.transform);
        transform.SetAsFirstSibling();

        if(!EventHandler.Instance.openQuests.Contains(gameObject))
            EventHandler.Instance.openQuests.Add(gameObject);
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        EventHandler.Instance.inventory.GetComponent<InventoryScript>().LoseItem(item, 1);
    }

    public void ResetPosition()
    {
        transform.position = startPos.transform.position;
        transform.SetParent(startPos.transform);

        while(items.Count > 0)
        {
            EventHandler.Instance.inventory.GetComponent<InventoryScript>().RecieveItem(items[0]);
            items.RemoveAt(0);
        }
    }

#endregion
    public void Select()
    {
        if(canBeSelected)
            EventHandler.Instance.selected = gameObject;
    }

    public void HeroAssigned(GameObject hero)
    {
        quest.assignedHero = hero;
    }
}
