using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyTop : MonoBehaviour
{

    [SerializeField] private BadGuyBlock baddy;

    private float direction = 0;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = baddy.direction;
        baddy.direction = 0f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        baddy.direction = direction;
    }
}
