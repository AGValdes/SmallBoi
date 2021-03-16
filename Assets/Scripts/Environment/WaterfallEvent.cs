using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallEvent : MonoBehaviour
{
    [SerializeField] private Sprite newBoii;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name + " : " + gameObject.name + " : ");
        collision.gameObject.GetComponent<SpriteRenderer>().sprite = newBoii;

        
    }
}
