using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Armor")]
public class Armor : Item
{
    public int protection;
    public int weightlessness;
    public int magicResist;
    public int manaStorage;
    public int stealth;

    public override void SetUpItem(GameObject item)
    {
        base.SetUpItem(item);
    }
}
