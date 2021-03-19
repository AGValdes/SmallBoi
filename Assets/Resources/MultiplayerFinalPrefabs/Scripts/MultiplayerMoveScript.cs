using System;
using Photon.Pun;
using UnityEngine;

public class MultiplayerMoveScript : MonoBehaviour
{
  [SerializeField] private LayerMask playerLayerMask;
  [SerializeField] private LayerMask grounded;

  public float speed = 5f;
  private PhotonView photonView;
  private Rigidbody2D rigidBody2D;
  private BoxCollider2D boxCollider2D;
  private float jumpVelocity = 0;
  private int direction;
  private SpriteRenderer sprite;
  private MultiPlayerRPC RPCConnection;

  // Start is called before the first frame update
  void Start()
  {
    rigidBody2D = transform.GetComponent<Rigidbody2D>();
    boxCollider2D = transform.GetComponent<BoxCollider2D>();
    sprite = GetComponent<SpriteRenderer>();
    photonView = GetComponent<PhotonView>();
    RPCConnection = GetComponent<MultiPlayerRPC>();
  }

  // Update is called once per frame
  void FixedUpdate()
  {
    if (photonView.IsMine && PhotonNetwork.IsConnected)
    {
      // may toggle speed run
      direction = Convert.ToInt32(Input.GetAxis("Horizontal"));
      Vector3 move = new Vector3(direction, 0.0f, 0.0f);

      if(Input.GetAxis("Horizontal") < 0)
      {
        sprite.flipX = true;
      }
      
      if(Input.GetAxis("Horizontal") > 0)
      {
        sprite.flipX = false;
      }

      this.transform.position = this.transform.position + ((move * Time.deltaTime) * speed);

      if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)) && IsGrounded())
      {
        jumpVelocity = 7f;
        rigidBody2D.velocity = Vector2.up * jumpVelocity;
      }
    }
  }

  /// <summary>
  /// Makes sure the player is not in the air.
  /// </summary>
  /// <returns>bool</returns>
  private bool IsGrounded()
  {
    RaycastHit2D raycastPlatform = Physics2D.BoxCast(boxCollider2D.bounds.center,
        boxCollider2D.bounds.size, 0f, Vector2.down, .1f, grounded);

    if (raycastPlatform)
    {
      return true;
    }
    return false;
  }
}