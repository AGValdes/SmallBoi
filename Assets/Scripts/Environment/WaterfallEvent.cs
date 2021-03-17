using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallEvent : MonoBehaviour
{
  [SerializeField] private Animator newBoii;
  [SerializeField] private Animation smolBoiAnimation;
  


	private void OnTriggerEnter2D(Collider2D collision)
  {
    Debug.Log(gameObject.name);
    if (gameObject.CompareTag("BlueWaterfall"))
    {
      PlayerOne playerOne = collision.GetComponent<PlayerOne>();
      playerOne.color = "blue";
      Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : ");
      collision.gameObject.GetComponent<Animator>().Play("Base Layer.PlayerTwoLeft");
      
		}
    //else 
    //{
    //  collision.gameObject.GetComponent<Animator>().Play("Base Layer.PlayerOneLeft");
    //}
  }
}
