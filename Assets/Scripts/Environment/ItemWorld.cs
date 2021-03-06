using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{

    private Item item;
    private SpriteRenderer spriteRenderer;

  public PlayerOne player1;

  public PlayerTwo player2;
  private HealthBarScript healthbar;

	private void Start()
	{
    player1 = gameObject.GetComponent<PlayerOne>();
    player2 = gameObject.GetComponent<PlayerTwo>();
  }

	public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
       
    }

    public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
    {
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);

        return itemWorld;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
    //TODO: include item effects here! (or inventory add here!)
    if (collision.gameObject.CompareTag("player 1"))
    {
      player1.CurrentHealth += 5;
      healthbar.SetHealth(player1.CurrentHealth);
    }

    if (collision.gameObject.CompareTag("player 2"))
    {
      player2.CurrentHealth += 5;
      healthbar.SetHealth(player2.CurrentHealth);
    }
    DestroySelf();
    }

    public void SetItem(Item item)
    {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }

    public Item GetItem()
    {
        return item;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
