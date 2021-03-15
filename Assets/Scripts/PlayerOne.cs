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

        // may toggle speed run
        Vector3 move = new Vector3();
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = -1;
            float speedAdjust = InAir(direction);
            move = new Vector3(speedAdjust, 0.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = 1;
            float speedAdjust = InAir(direction);
            move = new Vector3(speedAdjust, 0.0f, 0.0f);
        }

        this.transform.position = this.transform.position + ((move * Time.deltaTime) * speed);

        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            jumpVelocity = 5f;
            rigidBody2D.velocity = Vector2.up * jumpVelocity;
        }
        
        if (!IsGrounded())
        {
            move = new Vector3(direction, 0.0f, 0.0f);
            this.transform.position = this.transform.position + ((move * Time.deltaTime) * speed);
        }
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

    private float InAir(float speed) => IsGrounded() ? speed : (speed * 0.1f);

}
