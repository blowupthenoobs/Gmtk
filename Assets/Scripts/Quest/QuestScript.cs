using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DataCollections;

public class QuestScript : MonoBehaviour
{
    public DefaultQuestData originalData;
    public QuestData quest;
    public GameObject draggablePart;

    void Update()
    {
        quest.Update();
    }

    public void SetQuestData(DefaultQuestData defaultQuestData)
    {
        quest = (QuestData)ScriptableObject.CreateInstance(typeof(QuestData));
        draggablePart.GetComponent<QuestAssignScript>().quest = quest;
        quest.SetUpQuestDetails(defaultQuestData);
    }
}
