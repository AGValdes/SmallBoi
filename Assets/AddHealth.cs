using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{

  [SerializeField]
  public PlayerOne player1;
  [SerializeField]
  public PlayerTwo player2;
  [SerializeField]
  private HealthBarScript healthbar;






  
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
      //TODO: include item effects here! (or inventory add here!)
      if (collision.gameObject.CompareTag("player 1"))
      {
        Debug.Log(player1);
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

  public void DestroySelf()
  {
    Destroy(gameObject);
  }
}
