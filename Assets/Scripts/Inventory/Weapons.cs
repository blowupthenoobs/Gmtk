using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Weapons")]
public class Weapons : Item
{
    public int damage;
    public int range;
    public int speed;

    public override void SetUpItem(GameObject item)
    {
        base.SetUpItem(item);
        Debug.Log(item + "tis a weapon");
    }
}
