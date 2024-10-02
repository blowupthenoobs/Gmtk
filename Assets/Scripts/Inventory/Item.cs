using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DataCollections;

public class Item : ScriptableObject
{
    public List<role> type = new List<role>();
    public int normalValue;
    public Sprite image;

    public virtual void SetUpItem(GameObject item)
    {
        item.GetComponent<UnityEngine.UI.Image>().overrideSprite = image;
    }
}
