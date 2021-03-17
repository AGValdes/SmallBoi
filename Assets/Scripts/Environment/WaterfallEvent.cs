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
 
    RaycastHit2D raycast = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.up, .1f, layer);
   // if(raycast)
   // {
      Debug.Log("hellloo");
      newScale.y = .5f;
      gameObject.transform.localScale = newScale;
		//}
	}
}
