using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerOneMultiplayer : MonoBehaviour
{
  public Animator animator;

  public float speed = 5f;
  PhotonView photonView;
  private Rigidbody2D rigidBody2D;
  private BoxCollider2D boxCollider2D;
  [SerializeField] private LayerMask platformLayerMask;
  [SerializeField] private LayerMask playerLayerMask;
  [SerializeField] private LayerMask enemyLayerMask;

  private float jumpVelocity = 0;

  private int direction;
  void Start()
  {
    animator = GetComponent<Animator>();
    photonView = GetComponent<PhotonView>();
    rigidBody2D = transform.GetComponent<Rigidbody2D>();
    boxCollider2D = transform.GetComponent<BoxCollider2D>();

  }

  void Update()
  {
    //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));


    //============= Key presses ======================
    if (photonView.IsMine == true && PhotonNetwork.IsConnected == true)
    {
      if (Input.GetKey(KeyCode.DownArrow))
      {
        RaycastHit2D targetObj = GetThrowObj();
        float hor = 7f * direction;
        float vert = 7f;

        targetObj.collider.attachedRigidbody.velocity = new Vector2(hor, vert);
      }

      // may toggle speed run

      /// JPJ Mode For GetAxis to assess controller support
      Vector3 move = new Vector3();


      //if (Input.GetKey(KeyCode.LeftArrow))
      //{
      //  direction = -1;
      //  move = new Vector3(-1.0f, 0.0f, 0.0f);
      //}
      //else if (Input.GetKey(KeyCode.RightArrow))
      //{
      //  direction = 1;
      //  move = new Vector3(1.0f, 0.0f, 0.0f);
      //}

      this.transform.position = this.transform.position + new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0);

      if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
      {
        Debug.Log("Jump Attempted");
        jumpVelocity = 5f;
        rigidBody2D.velocity = Vector2.up * jumpVelocity;
      }
    }
  }
  //================= Methods ====================
  /// <summary>
  /// Makes sure the player is not int the air.
  /// </summary>
  /// <returns>bool</returns>
  private bool IsGrounded()
  {
    RaycastHit2D raycastPlatform = Physics2D.BoxCast(boxCollider2D.bounds.center,
        boxCollider2D.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
    RaycastHit2D raycastPlayer = Physics2D.BoxCast(boxCollider2D.bounds.center,
    boxCollider2D.bounds.size, 0f, Vector2.down, .1f, playerLayerMask);
    //raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center,
    //boxCollider2D.bounds.size, 0f, Vector2.down, .1f, enemyLayerMask);

    if (raycastPlatform || raycastPlayer)
    {
      return true;
    }
    return false;
  }

  /// <summary>
  /// Finds which edge collision occured on and moves child object with parent
  /// </summary>
  /// <param name="collision">Collision2D</param>
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.collider.CompareTag("player 2"))
    {
      Collision2DSideTypeMultiplayer collisionSide = collision.GetContactSideMultiplayer();
      if (collisionSide == Collision2DSideTypeMultiplayer.Top)
      {
        collision.collider.transform.SetParent(transform);
      }
    }
  }
  /// <summary>
  /// Removes the connection between parent and child
  /// </summary>
  /// <param name="collision2D"></param>
  private void OnCollisionExit2D(Collision2D collision2D)
  {
    collision2D.collider.transform.parent = null;
  }
  /// <summary>
  /// Gets object on top of this object
  /// </summary>
  /// <returns>RaycastHit2D</returns>
  private RaycastHit2D GetThrowObj()
  {
    RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center,
        boxCollider2D.bounds.size, 0f, Vector2.up, .1f, playerLayerMask);

    return raycastHit2D;
  }


}




//===================== Collision side stuff ==========================
public enum Collision2DSideTypeMultiplayer
{
  None,
  Left,
  Right,
  Top,
  Bottom,
}

public static class Collision2DExtensions
{
  public static Collision2DSideTypeMultiplayer GetContactSideMultiplayer(Vector2 max, Vector2 center, Vector2 contact)
  {
    Collision2DSideTypeMultiplayer side = Collision2DSideTypeMultiplayer.None;
    float diagonalAngle = Mathf.Atan2(max.y - center.y, max.x - center.x) * 180 / Mathf.PI;
    float contactAngle = Mathf.Atan2(contact.y - center.y, contact.x - center.x) * 180 / Mathf.PI;
    if (contactAngle < 0)
    {
      contactAngle = 360 + contactAngle;
    }
    if (diagonalAngle < 0)
    {
      diagonalAngle = 360 + diagonalAngle;
    }
    if (
        ((contactAngle >= 360 - diagonalAngle) && (contactAngle <= 360)) ||
        ((contactAngle <= diagonalAngle) && (contactAngle >= 0))
    )
    {
      side = Collision2DSideTypeMultiplayer.Right;
    }
    else if (
        ((contactAngle >= 180 - diagonalAngle) && (contactAngle <= 180)) ||
        ((contactAngle >= 180) && (contactAngle <= 180 + diagonalAngle))
    )
    {
      side = Collision2DSideTypeMultiplayer.Left;
    }
    else if (
        ((contactAngle >= diagonalAngle) && (contactAngle <= 90)) ||
        ((contactAngle >= 90) && (contactAngle <= 180 - diagonalAngle))
    )
    {
      side = Collision2DSideTypeMultiplayer.Top;
    }
    else if (
        ((contactAngle >= 180 + diagonalAngle) && (contactAngle <= 270)) ||
        ((contactAngle >= 270) && (contactAngle <= 360 - diagonalAngle))
    )
    {
      side = Collision2DSideTypeMultiplayer.Bottom;
    }
    return side.OppositeMultiplayer();
  }
  public static Collision2DSideTypeMultiplayer GetContactSideMultiplayer(this Collision2D collision)
  {
    Vector2 max = collision.collider.bounds.max;
    Vector2 center = collision.collider.bounds.center;
    Vector2 contact = collision.GetContact(0).point;
    return GetContactSideMultiplayer(max, center, contact);
  }
}

public static class Collision2DSideTypeMultiplayerClass
{
  public static Collision2DSideTypeMultiplayer OppositeMultiplayer(this Collision2DSideTypeMultiplayer sideType)
  {
    Collision2DSideTypeMultiplayer opposite;
    if (sideType == Collision2DSideTypeMultiplayer.Left)
    {
      opposite = Collision2DSideTypeMultiplayer.Right;
    }
    else if (sideType == Collision2DSideTypeMultiplayer.Right)
    {
      opposite = Collision2DSideTypeMultiplayer.Left;
    }
    else if (sideType == Collision2DSideTypeMultiplayer.Top)
    {
      opposite = Collision2DSideTypeMultiplayer.Bottom;
    }
    else if (sideType == Collision2DSideTypeMultiplayer.Bottom)
    {
      opposite = Collision2DSideTypeMultiplayer.Top;
    }
    else
    {
      opposite = Collision2DSideTypeMultiplayer.None;
    }
    return opposite;
  }

}


