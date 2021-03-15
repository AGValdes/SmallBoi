using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    public Animator animator;

    public float speed = 5f;

    private Rigidbody2D rigidBody2D;
    private BoxCollider2D boxCollider2D;

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

        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpVelocity = 5f;
            rigidBody2D.velocity = Vector2.up * jumpVelocity;
        }
    }

    private void Jump()
    {

    }
}
