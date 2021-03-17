using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallEvent : MonoBehaviour
{
  [SerializeField] private Animator newBoii;
    

  private void OnTriggerEnter2D(Collider2D collision)
  {
    Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : ");
    collision.gameObject.GetComponent<Animator>().Play("Base Layer.BaldyWalk");
  }
}
