using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyBottom : MonoBehaviour
{
    [SerializeField] private BadGuyBlock baddy;
    private new Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = baddy.gameObject.GetComponent<Rigidbody2D>();
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        //if collider = desired spot baddy.direction = 0 to stop movement
        if (!collision.collider.CompareTag("plat"))
        {
            baddy.direction = baddy.direction == 1 ? -1 : 1;
        }
    }

}
