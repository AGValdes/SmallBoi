using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabMoveable : MonoBehaviour
{
    [SerializeField] private Transform grabDetect;
    [SerializeField] private Transform container;
    [SerializeField] private float dist;

    [SerializeField]
    private void Update()
    {
        RaycastHit2D canGrab = Physics2D.Raycast(grabDetect.position, Vector2.right, dist);
        if (!canGrab)
        {
            canGrab = Physics2D.Raycast(grabDetect.position, Vector2.left, dist);
        }

        if (canGrab && canGrab.collider.CompareTag("moveable"))
        {
            if (gameObject.tag == "player 1")
            {
                if (Input.GetKey(KeyCode.RightShift))
                {
                    canGrab.collider.gameObject.transform.parent = container;
                    canGrab.collider.gameObject.transform.position = container.position;
                    canGrab.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                }
                else
                {
                    canGrab.collider.gameObject.transform.parent = null;
                    canGrab.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                }
            }
            if (gameObject.tag == "player 2")
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    canGrab.collider.gameObject.transform.parent = container;
                    canGrab.collider.gameObject.transform.position = container.position;
                    canGrab.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                }
                else
                {
                    canGrab.collider.gameObject.transform.parent = null;
                    canGrab.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                }
            }
        }
    }
}
