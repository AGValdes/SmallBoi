using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddStars : MonoBehaviour
{
  [SerializeField]
  public PlayerOne player1;
  [SerializeField]
  public PlayerTwo player2;
  [SerializeField]
  public StarBar starbar;

  // Update is called once per frame
  void Update()
    {
        
    }

  public void OnTriggerEnter2D(Collider2D collision)
  {
    //TODO: include item effects here! (or inventory add here!)
    if (collision.gameObject.CompareTag("player 1"))
    {
      Debug.Log(player1);
      player1.CurrentNumberOFStars += 1;
      starbar.SetStar(player1.CurrentNumberOFStars);
    }

    if (collision.gameObject.CompareTag("player 2"))
    {
      player1.CurrentNumberOFStars += 1;
      starbar.SetStar(player1.CurrentNumberOFStars);
    }
    DestroySelf();
  }

  public void DestroySelf()
  {
    Destroy(gameObject);
  }
}
