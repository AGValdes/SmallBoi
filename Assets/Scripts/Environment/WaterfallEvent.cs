using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallEvent : MonoBehaviour
{
  [SerializeField] private Animator newBoii;
  [SerializeField] private Animation smolBoiAnimation;
  [SerializeField] private LayerMask layer;
  private Vector3 newScale;
  private BoxCollider2D collider;
  private GameObject waterfall;
  


	private void Start()
	{
    collider = transform.GetComponent<BoxCollider2D>();
    waterfall = transform.GetComponent<GameObject>();
	}
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

	private void OnCollisionEnter2D(Collision2D collision)
	{

		if(collision.gameObject.CompareTag("moveable"))
		{
		Debug.Log("hellloo");
		newScale.y = .2f;
		newScale.x = 1.037243f;
		gameObject.transform.GetChild(0).localScale = newScale;
		gameObject.transform.GetChild(0).position += Vector3.up * 3.29f;
	}
}

	private void OnCollisionStay2D(Collision2D collision)
	{
    if (collision.gameObject.CompareTag("moveable"))
    {
    newScale.y = .2f;
    newScale.x = 1.037243f;
    gameObject.transform.GetChild(0).localScale = newScale;
		}
   
  }

	private void OnCollisionExit2D(Collision2D collision)
	{

    if (collision.gameObject.CompareTag("moveable"))
    {
      newScale.y = 1.498861f;
      newScale.x = 1.037243f;
      gameObject.transform.GetChild(0).localScale = newScale;
      gameObject.transform.GetChild(0).position -= Vector3.up * 3.29f;
    }
  }
}
