using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnPlatform : MonoBehaviour
{
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("player 1") || collision.gameObject.CompareTag("player 2"))
    {
      collision.collider.transform.SetParent(transform);
    }
  }
  private void OnCollisionExit2D(Collision2D collision)
  {
    collision.collider.transform.parent = null;
  }
}
