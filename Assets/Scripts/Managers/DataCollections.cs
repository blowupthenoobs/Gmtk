using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataCollections
{
    public enum NodeType{Adventure, Looting, Combat}
    public enum role {Warrior, Mage, Medic, Rogue, Archer};

    public struct DefaultQuestData
    {
        public string name;
        public string description;
        public int difficulty;
        public string missionType;
        public int nodeGroups;
        public int minAdventure;
        public int maxAdventure;
        public int minLooting;
        public int maxLooting;
        public int minCombat;
        public int maxCombat;
        public bool mainQuest;
        public int minTimeLimit;
        public int maxTimeLimit;



        public DefaultQuestData(string name, string description, int difficulty, string missionType, int nodeGroups, int minAdventure, int maxAdventure, int minLooting, int maxLooting, int minCombat, int maxCombat, bool mainQuest, int minTimeLimit, int maxTimeLimit)
        {
            this.name = name;
            this.description = description;
            this.difficulty = difficulty;
            this.missionType = missionType;
            this.nodeGroups = nodeGroups;
            this.minAdventure = minAdventure;
            this.maxAdventure = maxAdventure;
            this.minLooting = minLooting;
            this.maxLooting = maxLooting;
            this.minCombat = minCombat;
            this.maxCombat = maxCombat;
            this.mainQuest = mainQuest;
            this.minTimeLimit = minTimeLimit;
            this.maxTimeLimit = maxTimeLimit;
        }

        
    }

    public class MissionSets
    {
        public DefaultQuestData celeryCreatures = new DefaultQuestData
        (
            name: "Attack of the Celery Creatures",
            description: "Save the world from a vast swarm of invading celery creatures",
            difficulty: 3,
            missionType: "Assault",
            nodeGroups: 5,
            minAdventure: 3,
            maxAdventure: 7,
            minLooting: 2,
            maxLooting: 5,
            minCombat: 7,
            maxCombat: 20,
            mainQuest: true,
            minTimeLimit: 150,
            maxTimeLimit: 200
        );
    }
    
}
