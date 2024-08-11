using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    public QuestData quest;

    public void SetQuestData(int length)
    {
        quest = (QuestData)ScriptableObject.CreateInstance(typeof(QuestData));
        quest.questLength = length;
    }
}
