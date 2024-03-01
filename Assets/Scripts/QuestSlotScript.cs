using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSlotScript : MonoBehaviour
{
    public GameObject inventory;
    public GameObject originalQuestPos;
    public GameObject quest;
    public GameObject draggableQuest;
    public bool hasItem;

    public void VisualizeItem(GameObject newQuest)
    {
        hasItem = true;
        quest = Instantiate(newQuest, transform.position, gameObject.transform.rotation);
        quest.transform.SetParent(gameObject.transform);
    }

    public void RemoveItem()
    {
        Destroy(quest);
        quest = null;
        hasItem = false;
    }
}
