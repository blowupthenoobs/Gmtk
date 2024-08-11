using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    public QuestData quest;
    public GameObject draggablePart;

    void Update()
    {
        quest.Update();
    }

    public void SetQuestData(int length)
    {
        quest = (QuestData)ScriptableObject.CreateInstance(typeof(QuestData));
        draggablePart.GetComponent<QuestAssignScript>().quest = quest;
        quest.questLength = length;
    }
}
