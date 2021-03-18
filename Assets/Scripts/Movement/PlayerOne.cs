using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;

public class PlayerOne : MonoBehaviour
{
    public Animator animator;

    public float speed = 5f;
 
    private Rigidbody2D rigidBody2D;
    private BoxCollider2D boxCollider2D;
    private Vector3 newScale;

    [SerializeField] private LayerMask playerLayerMask;
    [SerializeField] private LayerMask grounded;
     public string color;

/// <summary>
/// /////////health stuf
/// </summary>
      private int MaxHealth = 20;

       [SerializeField]
      public int CurrentHealth;

      [SerializeField]
      public HealthBarScript healthbar;

      [SerializeField]
      public StarBar starBar;
      
      public int CurrentNumberOFStars;
      private int MaxStars = 5;

      public PauseScreen pause;

/// <summary>
/// /////////
/// </summary>
    private float jumpVelocity = 0;

    private int direction;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody2D = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        newScale = gameObject.transform.localScale;
        CurrentHealth = MaxHealth;
        healthbar.SetMaxHealth(MaxHealth);
        starBar.SetMaxStars(MaxStars);
        CurrentNumberOFStars = 0;
    }

    void Update()
    {
       // animator.SetFloat("P1Horizontal", direction);
        if(CurrentHealth == 0)
        {
           CurrentHealth -= 1;
           PlayerDeath();
		    }

        //============= Key presses ======================
        if (Input.GetKey(KeyCode.DownArrow))
        {
            RaycastHit2D targetObj = GetThrowObj();
            float hor = 7f * direction;
            float vert = 7f;
            if (targetObj)
            {
                targetObj.collider.attachedRigidbody.velocity = new Vector2(hor, vert);
            }
        } 

        // may toggle speed run
        Vector3 move = new Vector3();
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(newScale.x >= 0)
            {
                newScale.x *= -1;
                gameObject.transform.localScale = newScale;
            }
            direction = -1;
            move = new Vector3(-1.0f, 0.0f, 0.0f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
             if (newScale.x <= 0)
            {
                newScale.x *= -1;
                gameObject.transform.localScale = newScale;
            }
            direction = 1;
            move = new Vector3(1.0f, 0.0f, 0.0f);
        }



        this.transform.position = this.transform.position + ((move * Time.deltaTime) * speed);

        if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
        {
            jumpVelocity = 7f;
            rigidBody2D.velocity = Vector2.up * jumpVelocity;
        }

    }

    private void FixedUpdate()
    {
        
    }

    /// <summary>
    /// Makes sure the player is not in the air.
    /// </summary>
    /// <returns>bool</returns>
    private bool IsGrounded()
    {
        RaycastHit2D raycastPlatform = Physics2D.BoxCast(boxCollider2D.bounds.center,
            boxCollider2D.bounds.size, 0f, Vector2.down, .1f, grounded);
        //RaycastHit2D raycastPlayer = Physics2D.BoxCast(boxCollider2D.bounds.center,
        //boxCollider2D.bounds.size, 0f, Vector2.down, .1f, grounded);
        //raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center,
        //boxCollider2D.bounds.size, 0f, Vector2.down, .1f, enemyLayerMask);

        if(raycastPlatform)
        {
            return true;
        }
        return false;
    }

	/// <summary>
	/// Finds which edge collision occured on and moves child object with parent
	/// </summary>
	/// <param name="collision">Collision2D</param>    
	//private void OnCollisionEnter2D(Collision2D collision)
	//{

	//	RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center,
	//			boxCollider2D.bounds.size, 0f, Vector2.up, .1f, playerLayerMask);

	//	if (raycastHit2D)
	//	{
	//		raycastHit2D.collider.transform.SetParent(transform);
	//	}
	//}

	/// <summary>
	/// Removes the connection between parent and child
	/// </summary>
	/// <param name="collision2D"></param>
	private void OnCollisionExit2D(Collision2D collision2D)
    {
        //collision2D.collider.transform.parent = null;
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

    void PlayerDeath()
    {
       pause.DeathPause();
	  }

}
