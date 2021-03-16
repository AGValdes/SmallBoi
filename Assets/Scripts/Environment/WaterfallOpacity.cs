using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallOpacity : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
      
      foreach (Transform child in transform)
      {
        child.GetComponent<SpriteRenderer>().color = new Color (1, 1, 1, .6f);
      }
      
    }

    void OnTriggerExit2D(Collider2D collision)
    {

      foreach (Transform child in transform)
      {
        child.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .78f);
      }
    }
}
