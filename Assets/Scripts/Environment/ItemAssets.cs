using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public Sprite SerotoninSprite;
    public Sprite StarSprite;

    public static ItemAssets Instance { get; private set; }
    public Transform pfItemWorld;

    private void Awake()
    {

        Instance = this;

        //call opening level item spawns here:
        //TEMPLATE: ItemWorld.SpawnItemWorld(new Vector2(4.5f, -0.04f), new Item { itemType = Item.ItemType.[ITEM TYPE HERE] });

        //ItemWorld.SpawnItemWorld(new Vector2(-7.97f, 4.25f), new Item { itemType = Item.ItemType.serotoninCrumb });
        //ItemWorld.SpawnItemWorld(new Vector3(0.68f, 1.15f, -5.0f), new Item { itemType = Item.ItemType.star });

    }
}
