using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    public Animator animator;

    public float speed = 5f;

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

        rigidBody2D = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));

        if (Input.GetKey(KeyCode.DownArrow))
        {
            RaycastHit2D targetObj = Throw();


            jumpVelocity = 5f;
            targetObj.rigidBody2D.velocity = Vector2.up * jumpVelocity;



        }

        // may toggle speed run
        Vector3 move = new Vector3();
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1;
            move = new Vector3(-1.0f, 0.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1;
            move = new Vector3(1.0f, 0.0f, 0.0f);
        }

        this.transform.position = this.transform.position + ((move * Time.deltaTime) * speed);

        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            jumpVelocity = 5f;
            rigidBody2D.velocity = Vector2.up * jumpVelocity;
        }

        //if (!IsGrounded())
        //{
        //    move = new Vector3(direction, 0.0f, 0.0f);
        //    this.transform.position = this.transform.position + ((move * Time.deltaTime) * speed);
        //}
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center,
            boxCollider2D.bounds.size, 0f, Vector2.down, .1f, platformLayerMask);
        //raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center,
        //boxCollider2D.bounds.size, 0f, Vector2.down, .1f, playerLayerMask);
        //raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center,
        //boxCollider2D.bounds.size, 0f, Vector2.down, .1f, enemyLayerMask);
        return raycastHit2D.collider != null;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("player 2"))
    //    {

    //        Collision2DSideType collisionSide = collision.GetContactSide();
    //        if (collisionSide == Collision2DSideType.Top)
    //        {
                
    //        }
    //    }
    //}


    private RaycastHit2D Throw()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center,
            boxCollider2D.bounds.size, 0f, Vector2.up, .1f, playerLayerMask);
        
        if(raycastHit2D.collider != null)
        {
             return raycastHit2D;          
        }
        return null;
    }


}




//===================== Collision side stuff ==========================
public enum Collision2DSideType
{
    None,
    Left,
    Right,
    Top,
    Bottom,
}
public static class Collision2DExtensions
{
    public static Collision2DSideType GetContactSide(Vector2 max, Vector2 center, Vector2 contact)
    {
        Collision2DSideType side = Collision2DSideType.None;
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
            side = Collision2DSideType.Right;
        }
        else if (
            ((contactAngle >= 180 - diagonalAngle) && (contactAngle <= 180)) ||
            ((contactAngle >= 180) && (contactAngle <= 180 + diagonalAngle))
        )
        {
            side = Collision2DSideType.Left;
        }
        else if (
            ((contactAngle >= diagonalAngle) && (contactAngle <= 90)) ||
            ((contactAngle >= 90) && (contactAngle <= 180 - diagonalAngle))
        )
        {
            side = Collision2DSideType.Top;
        }
        else if (
            ((contactAngle >= 180 + diagonalAngle) && (contactAngle <= 270)) ||
            ((contactAngle >= 270) && (contactAngle <= 360 - diagonalAngle))
        )
        {
            side = Collision2DSideType.Bottom;
        }
        return side.Opposite();
    }
    public static Collision2DSideType GetContactSide(this Collision2D collision)
    {
        Vector2 max = collision.collider.bounds.max;
        Vector2 center = collision.collider.bounds.center;
        Vector2 contact = collision.GetContact(0).point;
        return GetContactSide(max, center, contact);
    }
}
public static class Collision2DSideTypeExtensions
{
    public static Collision2DSideType Opposite(this Collision2DSideType sideType)
    {
        Collision2DSideType opposite;
        if (sideType == Collision2DSideType.Left)
        {
            opposite = Collision2DSideType.Right;
        }
        else if (sideType == Collision2DSideType.Right)
        {
            opposite = Collision2DSideType.Left;
        }
        else if (sideType == Collision2DSideType.Top)
        {
            opposite = Collision2DSideType.Bottom;
        }
        else if (sideType == Collision2DSideType.Bottom)
        {
            opposite = Collision2DSideType.Top;
        }
        else
        {
            opposite = Collision2DSideType.None;
        }
        return opposite;
    }

}


