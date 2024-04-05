using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotManagerScript : MonoBehaviour
{
    [SerializeField] List<GameObject> SlotSet = new List<GameObject>();
    [SerializeField] Vector3 changeDistance;
    [SerializeField] GameObject SlotPrefab;
    [SerializeField] GameObject SetContainer;

    void Awake()
    {
        CreateNewSlot();
    }

    public void CreateNewSlot()
    {
        SlotSet.Add(Instantiate(SlotPrefab, SlotSet[SlotSet.Count - 1].transform.position + changeDistance * ScreenCalculations.GetScale(gameObject), transform.rotation));

        SlotSet[SlotSet.Count - 1].transform.SetParent(SetContainer.transform);
        SlotSet[SlotSet.Count - 1].transform.localScale = new Vector3(1f, 1f, 1f);
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
}
