using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSlotScript : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    GameObject quest;
    [SerializeField] GameObject QuestPos;
    public bool hasItem;

    public void VisualizeItem(GameObject newQuest)
    {
        hasItem = true;
        quest = newQuest;
        GameObject Visual = Instantiate(newQuest, QuestPos.transform.position, gameObject.transform.rotation);
        Visual.transform.SetParent(gameObject.transform);
        Visual.transform.localScale = new Vector3(1f, 1f, 1f);
        Visual.SendMessage("SetQuestData", inventory.GetComponent<QuestInventoryScript>().missionSets.celeryCreatures); //Temporarially put in forced mission
        // Visual.transform.localPosition = new Vector2((Visual.GetComponent<RectTransform>().), 0f);
    }

    public void RemoveItem()
    {
        Destroy(quest);
        quest = null;
        hasItem = false;
    }
}
