using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapons")]
public class Weapons : Item
{
    public int damage;
    public int range;
    public int speed;
    public float dps;
    public int penetrationPower;
    public int stun;
    public int bleed;
    public int manaEfficiency;
    public int weight;

    public override void SetUpItem(GameObject item)
    {
        base.SetUpItem(item);
    }
}
