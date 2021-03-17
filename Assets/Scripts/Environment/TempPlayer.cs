using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayer : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField] private float speed = 10F;
    [SerializeField] private float jumpSpeed = 10F;
    // [SerializeField] private float HP = 50f;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //rigidbody.gravityScale = 35;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0, Space.World);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        if ((hit != false) && (Input.GetKeyDown(KeyCode.Space)))
        {

            Jump();

        }

    }
    void Jump()
    {

        rigidbody.velocity = new Vector2(0, jumpSpeed);


    }
}
