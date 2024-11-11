using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DataCollections;

public class Hero : ScriptableObject
{
    public role classType;
    public float damagePref;
    public float rangePref;
    public float speedPref;
    public float dpsPref;
    public float penetrationPowerPref;
    public float stunPref;
    public float bleedPref;
    public float manaEfficiencyPref;
    public float weightPref;

    public float protectionPref;
    public float weightlessnessPref;
    public float magicResistPref;
    public float manaStoragePref;
    public float stealthPref;

    public float sideQuestValueReq;
    public float mainQuestValueReq;

    public Weapons currentWeapon;
    public Armor currentArmor;
    public List<Item> inventory = new List<Item>();
    public int money;

    public void RandomizeValues()
    {
        damagePref = Random.Range(1, 20) * (float).1;
        rangePref = Random.Range(1, 20) * (float).1;
        speedPref = Random.Range(1, 20) * (float).1;
        dpsPref = Random.Range(1, 20) * (float).1;
        penetrationPowerPref = Random.Range(1, 20) * (float).1;
        stunPref = Random.Range(1, 20) * (float).1;
        bleedPref = Random.Range(1, 20) * (float).1;
        manaEfficiencyPref = Random.Range(1, 20) * (float).1;
        weightPref = Random.Range(1, 20) * (float).1;
        protectionPref = Random.Range(1, 20) * (float).1;
        weightlessnessPref = Random.Range(1, 20) * (float).1;
        magicResistPref = Random.Range(1, 20) * (float).1;
        manaStoragePref = Random.Range(1, 20) * (float).1;
        stealthPref = Random.Range(1, 20) * (float).1;

        sideQuestValueReq = Random.Range(0, 5);
        mainQuestValueReq = Random.Range(0, 5);

        int rng = Random.Range(1, 6);

        switch(rng)
        {
            case 1:
            classType = role.Warrior;
            manaStoragePref = 0;
            manaEfficiencyPref = 0;
            stealthPref = 0;
            stunPref += Random.Range(1, 20) * (float).1;
            penetrationPowerPref += Random.Range(1, 20) * (float).1;
            break;
            case 2:
            classType = role.Mage;
            bleedPref = 0;
            magicResistPref += Random.Range(1, 20) * (float).1;
            stealthPref = 0;
            break;
            case 3:
            classType = role.Medic;
            manaStoragePref = 0;
            bleedPref = 0;
            manaEfficiencyPref = 0;
            stealthPref = 0;
            break;
            case 4:
            classType = role.Rogue;
            stunPref += Random.Range(1, 20) * (float).1;
            weightlessnessPref += Random.Range(1, 20) * (float).1;
            manaStoragePref = 0;
            manaEfficiencyPref = 0;
            break;
            case 5:
            classType = role.Archer;
            manaStoragePref = 0;
            manaEfficiencyPref = 0;
            break;
        }
    }

    public bool DecideToTakeMission(QuestData quest)
    {
        if(quest.originalData.mainQuest)
        {
            Debug.Log(mainQuestValueReq);
            Debug.Log(DecideMissionValue(quest.items));
            return (DecideMissionValue(quest.items) > mainQuestValueReq);
        }
        else
        {
            return (DecideMissionValue(quest.items) > sideQuestValueReq);
        }
    }

    public int DecideMissionValue(List<Item> missionRewards)
    {
        float value = 0;
        for(int i = 0; i < missionRewards.Count; i++)
        {
            if(missionRewards[i] is Weapons)
            {
                if(missionRewards[0].type.Contains(classType) && CompareWeaponPreferencialValue((Weapons)missionRewards[i]) > 0)
                    value += CompareWeaponPreferencialValue((Weapons)missionRewards[i]);
                else
                    value += missionRewards[i].normalValue;
            }
            else if(missionRewards[i] is Armor)
            {
                if(missionRewards[0].type.Contains(classType) && CompareArmorPreferencialValue((Armor)missionRewards[i]) > 0)
                    value += CompareArmorPreferencialValue((Armor)missionRewards[i]);
                else
                    value += missionRewards[i].normalValue;
            }
        }
        
        return (int)value;
    }

    public void RecieveItems(List<Item> missionRewards)
    {
        while(missionRewards.Count > 0)
        {
            if(missionRewards[0] is Weapons)
            {
                if(missionRewards[0].type.Contains(classType) && CompareWeaponPreferencialValue((Weapons)missionRewards[0]) > 0)
                {
                    money += currentWeapon.normalValue;
                    currentWeapon = (Weapons)missionRewards[0];
                }
                else
                    money += missionRewards[0].normalValue;
            }
            else if(missionRewards[0] is Armor)
            {
                if(missionRewards[0].type.Contains(classType) && CompareArmorPreferencialValue((Armor)missionRewards[0]) > 0)
                {
                    money += currentArmor.normalValue;
                    currentArmor = (Armor)missionRewards[0];
                }
                else
                    money += missionRewards[0].normalValue;
            }
            else
            {
                if(missionRewards[0].type.Contains(classType))
                    inventory.Add(missionRewards[0]);
                else
                    money += missionRewards[0].normalValue;
            }

            missionRewards.RemoveAt(0);
        }
    }

    public float CompareWeaponPreferencialValue(Weapons otherWeapon)
    {
        float value = 0;

        value += (otherWeapon.damage - currentWeapon.damage) * damagePref;
        value += (otherWeapon.range - currentWeapon.range) * rangePref;
        value += (otherWeapon.speed - currentWeapon.speed) * speedPref;
        value += (otherWeapon.dps - currentWeapon.dps) * dpsPref;
        value += (otherWeapon.penetrationPower - currentWeapon.penetrationPower) * penetrationPowerPref;
        value += (otherWeapon.stun - currentWeapon.stun) * stunPref;
        value += (otherWeapon.bleed - currentWeapon.bleed) * bleedPref;
        value += (otherWeapon.manaEfficiency - currentWeapon.manaEfficiency) * manaEfficiencyPref;
        value += (otherWeapon.weight - currentWeapon.weight) * weightPref;

        return value;
    }

    public float CompareArmorPreferencialValue(Armor otherArmor)
    {
        float value = 0;

        value += (otherArmor.protection - currentArmor.protection) * protectionPref;
        value += (otherArmor.weightlessness - currentArmor.weightlessness) * weightlessnessPref;
        value += (otherArmor.magicResist - currentArmor.magicResist) * magicResistPref;
        value += (otherArmor.manaStorage - currentArmor.manaStorage) * manaStoragePref;
        value += (otherArmor.stealth - currentArmor.stealth) * stealthPref;

        return value;
    }

}
