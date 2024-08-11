using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestData : ScriptableObject
{
    public int questLength;
    public int currentProgress;
    public GameObject assignedHero;
    public double gameTicks;


    void Update()
    {
        if(assignedHero != null)
        {
            gameTicks += Time.deltaTime;

            if(gameTicks >= 1)
            {
                gameTicks -= 1;
                NextAdventureNode();
            }
        }
    }

    void NextAdventureNode()
    {
        currentProgress += 1;

        if(currentProgress >= questLength)
            FinishQuest()
    }

    void FinishQuest()
    {
        Debug.Log("finished");
    }
}
