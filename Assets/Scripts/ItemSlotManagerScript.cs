using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotManagerScript : MonoBehaviour
{
    [SerializeField] List<GameObject> SlotSet = new List<GameObject>();
    [SerializeField] Vector3 changeDistance;
    [SerializeField] GameObject slotPrefab;
    [SerializeField] GameObject setContainer;
    [SerializeField] float moveSpeed;
    [SerializeField] bool moveVert;

    Vector3 originalContainerPos;

    Vector3 containerTargetPos;

    void Awake()
    {
        CreateNewSlot();

        originalContainerPos = setContainer.transform.position;
        containerTargetPos = originalContainerPos;
    }

    void Update()
    {
        if(!moveVert)
            containerTargetPos.x = setContainer.transform.position.x;
        else
            containerTargetPos.y = setContainer.transform.position.y;
        
        setContainer.transform.position = Vector3.MoveTowards(setContainer.transform.position, containerTargetPos, moveSpeed * ScreenCalculations.GetScale(gameObject) * Time.deltaTime);
    }

    public void CreateNewSlot()
    {
        SlotSet.Add(Instantiate(slotPrefab, SlotSet[SlotSet.Count - 1].transform.position + changeDistance * ScreenCalculations.GetScale(gameObject), transform.rotation));

        SlotSet[SlotSet.Count - 1].transform.SetParent(setContainer.transform);
        SlotSet[SlotSet.Count - 1].transform.localScale = new Vector3(1f, 1f, 1f);

        for(int i = 0; i < SlotSet[SlotSet.Count - 1].GetComponent<SlotSetScript>().slots.Length; i++)
        {
            gameObject.SendMessage("AddSlot", SlotSet[SlotSet.Count - 1].GetComponent<SlotSetScript>().slots[i]);
            SlotSet[SlotSet.Count - 1].GetComponent<SlotSetScript>().slots[i].SendMessage("SetInventory", gameObject);
        }

    }

    void SetAllSlotPositions()
    {
        for(int i = 0; i < SlotSet.Count; i++)
        {
            Vector3 Selfpos = transform.position;
            Selfpos += i * changeDistance * ScreenCalculations.GetScale(gameObject);
            
            SlotSet[i].transform.position = Selfpos;
        }
    }

    public void SlideSlots(int Direction)
    {
        containerTargetPos += changeDistance * ScreenCalculations.GetScale(gameObject) * -Direction;
    }
}
