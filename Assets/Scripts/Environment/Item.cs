using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    //TODO: expand class based on item behavior

    public ItemType itemType;

    public enum ItemType
    {
        serotoninCrumb,
        star
    }

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.serotoninCrumb: return ItemAssets.Instance.SerotoninSprite;
            case ItemType.star: return ItemAssets.Instance.StarSprite;
        }
    }
}
