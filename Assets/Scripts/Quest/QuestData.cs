using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DataCollections;

public class QuestData : ScriptableObject
{
    public DefaultQuestData originalData;
    public List<NodeType> questLength = new List<NodeType>();
    public int currentProgress;
    public GameObject assignedHero;
    public double gameTicks;
    public int timeLimit;

    public List<Item> items = new List<Item>();


    public void Update()
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

        if(currentProgress >= questLength.Count)
            FinishQuest();
    }

    void FinishQuest()
    {
        assignedHero.SendMessage("EnterBar");
        assignedHero.SendMessage("RecieveItems", items);
        assignedHero = null;
        //Do other things
    }

    public void SetUpQuestDetails(DefaultQuestData data)
    {
        originalData = data;

        for(int i = 0; i < Random.Range(data.minAdventure, data.maxAdventure); i++)
        {
            this.questLength.Add(NodeType.Adventure);
        }

        for(int i = 0; i < data.nodeGroups; i++)
        {
            var type = Random.Range(0, 3);

            switch(type)
            {
                case 0:
                for(int x = 0; x < Random.Range(data.minAdventure, data.maxAdventure); x++)
                {
                    questLength.Add(NodeType.Adventure);
                }
                break;
                case 1:
                for(int x = 0; x < Random.Range(data.minLooting, data.maxLooting); x++)
                {
                    questLength.Add(NodeType.Looting);
                }
                break;
                case 2:
                for(int x = 0; x < Random.Range(data.minCombat, data.minCombat); x++)
                {
                    questLength.Add(NodeType.Combat);
                }
                break;
            }
        }

        timeLimit = Random.Range(data.minTimeLimit, data.maxTimeLimit);
    }
}
