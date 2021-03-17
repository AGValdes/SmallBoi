using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssetsLVL2 : MonoBehaviour
{
    public Sprite SerotoninSprite;
    public Sprite StarSprite;

    public static ItemAssetsLVL2 Instance { get; private set; }
    public Transform pfItemWorld;

    private void Awake()
    {
        Instance = this;

        //call opening level item spawns here:
        //TEMPLATE: ItemWorld.SpawnItemWorld(new Vector2(4.5f, -0.04f), new Item { itemType = Item.ItemType.[ITEM TYPE HERE] });

        ItemWorld.SpawnItemWorld(new Vector2(-7.15f, 3.76f), new Item { itemType = Item.ItemType.star });
        ItemWorld.SpawnItemWorld(new Vector2(6.49f, -2.88f), new Item { itemType = Item.ItemType.star });
        ItemWorld.SpawnItemWorld(new Vector2(2.02f, -1.82f), new Item { itemType = Item.ItemType.star });

    }
}
