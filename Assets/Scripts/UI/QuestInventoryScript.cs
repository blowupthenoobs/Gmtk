using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DataCollections;

public class QuestInventoryScript : MonoBehaviour
{
    public GameObject[] itemSlots;
    public List<GameObject> quests = new List<GameObject>();

    public MissionSets missionSets = new MissionSets();


    public void RecieveQuest(GameObject quest)
    {
        quests.Add(quest);
        AssignItem(quest);
        // quest.SendMessage("SetUpQuestDetails", missionSets.celeryCreatures);
    }

    private void AssignItem(GameObject quest)
    {
        bool foundSpot = false;

        for(var i = 0; i < itemSlots.Length; i++)
        {
            if(!itemSlots[i].GetComponent<QuestSlotScript>().hasItem && !foundSpot)
            {
                itemSlots[i].GetComponent<QuestSlotScript>().VisualizeItem(quest);
                foundSpot = true;
            }
        }
    }

    public void FinishQuest(GameObject quest)
    {
        int QuestIndex = quests.IndexOf(quest);

        quests.RemoveAt(QuestIndex);
    }
}
