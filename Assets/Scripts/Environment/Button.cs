using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Sprite expectedSprite;
    //[SerializeField] private Sprite wallOpen;
    [SerializeField] private Sprite buttonDown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject wall = gameObject.transform.GetChild(0).gameObject;
        GameObject door = gameObject.transform.GetChild(1).gameObject;
        Debug.Log($"{expectedSprite} : {collision.gameObject.GetComponent<SpriteRenderer>().sprite}");
        if (expectedSprite == collision.gameObject.GetComponent<SpriteRenderer>().sprite)
        {
            wall.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = buttonDown;
            wall.GetComponent<Animator>().enabled = true;
            door.GetComponent<Animator>().enabled = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
