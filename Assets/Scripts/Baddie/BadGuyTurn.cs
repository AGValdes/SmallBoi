using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyTurn : MonoBehaviour
{
    [SerializeField] private BadGuyBlock baddy;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        baddy.direction = baddy.direction == 1 ? -1 : 1;
    }
}
