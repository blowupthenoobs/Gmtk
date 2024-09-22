using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public enum role {Warrior, Mage, Medic, Rogue, Archer};
    public List<role> type = new List<role>();
    public int value;
    public Sprite image;

    public virtual void SetUpItem(GameObject item)
    {
        item.GetComponent<UnityEngine.UI.Image>().overrideSprite = image;
    }
}
