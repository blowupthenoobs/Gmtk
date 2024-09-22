using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : ScriptableObject
{
    public enum role {Warrior, Mage, Medic, Rogue, Archer};
    public role class;
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

    public void RandomizeValues()
    {
        damagePref = Random.Range(0, 2);
        rangePref = Random.Range(0, 2);
        speedPref = Random.Range(0, 2);
        dpsPref = Random.Range(0, 2);
        penetrationPowerPref = Random.Range(0, 2);
        stunPref = Random.Range(0, 2);
        bleedPref = Random.Range(0, 2);
        manaEfficiencyPref = Random.Range(0, 2);
        weightPref = Random.Range(0, 2);
        protectionPref = Random.Range(0, 2);
        weightlessnessPref = Random.Range(0, 2);
        magicResistPref = Random.Range(0, 2);
        manaStoragePref = Random.Range(0, 2);
        stealthPref = Random.Range(0, 2);

        int rng = Random.Range(1, 6);

        switch(rng)
        {
            case 1:
            class = role.Warrior;
            break;
            case 2:
            class = role.Mage;
            break;
            case 3:
            class = role.Medic;
            break;
            case 4:
            class = role.Rogue;
            break;
            case 5:
            class = role.Archer;
            break;
        }
    }

}
