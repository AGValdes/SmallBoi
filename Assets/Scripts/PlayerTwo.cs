using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    public Animator animator;

    public float speed = 5f;

    private Rigidbody2D rigidBody2D;
    private BoxCollider2D boxCollider2D;

    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private LayerMask enemyLayerMask;

    private float jumpVelocity = 0;

    void Start()
    {
        animator = GetComponent<Animator>();

        rigidBody2D = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        Vector3 move = new Vector3();
        if (Input.GetKey(KeyCode.A))
        {
            move = new Vector3(-1.0f, 0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            move = new Vector3(1.0f, 0.0f, 0.0f);
        }
        this.transform.position = this.transform.position + ((move * Time.deltaTime) * speed);

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            jumpVelocity = 5f;
            rigidBody2D.velocity = Vector2.up * jumpVelocity;
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
}
