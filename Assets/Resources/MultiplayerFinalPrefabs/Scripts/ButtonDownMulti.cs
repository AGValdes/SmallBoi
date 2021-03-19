using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDownMulti : MonoBehaviour
{
  [SerializeField] private Animator player;
  //[SerializeField] private Sprite wallOpen;
  [SerializeField] private Sprite buttonDown;
  private GameObject playerObj;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    GameObject wall = gameObject.transform.GetChild(0).gameObject;
    GameObject door = gameObject.transform.GetChild(1).gameObject;
    player = collision.gameObject.transform.GetComponent<Animator>();
    playerObj = collision.gameObject;
    GameObject playerOne = collision.gameObject;
    GameObject playerTwo = collision.gameObject;
    if (collision.gameObject.name == "PlayerOneMultiPlayer(Clone)")
    {
    Debug.Log($"Collision Button {collision.gameObject.name}");
      string color1 = playerOne.GetComponent<PlayerOneColor>().color;
      if (color1 == "blue")
      {
        Debug.Log("openwall");
        wall.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonDown;
        wall.GetComponent<Animator>().enabled = true;
        door.GetComponent<Animator>().enabled = true;

      }
    }
    if (collision.gameObject.name == "PlayerTwoMultiPlayer(Clone)")
    {
      string color2 = playerTwo.GetComponent<PlayerTwoColor>().color;
      if (color2 == "blue")
      {
        Debug.Log("openwall");
        wall.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonDown;
        gameObject.GetComponent<SpriteRenderer>().sprite = buttonDown;
        wall.GetComponent<Animator>().enabled = true;
        door.GetComponent<Animator>().enabled = true;

      }
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

  bool AnimatorIsPlaying()
  {
    return player.GetCurrentAnimatorStateInfo(player.GetLayerIndex("PlayerTwoLeft")).length >
           player.GetCurrentAnimatorStateInfo(player.GetLayerIndex("PlayerTwoLeft")).normalizedTime;
  }
  bool AnimatorIsPlaying(string stateName)
  {
    return AnimatorIsPlaying() && player.GetCurrentAnimatorStateInfo(player.GetLayerIndex("PlayerTwoLeft")).IsName(stateName);
  }


}


