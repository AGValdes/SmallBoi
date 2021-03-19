using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyBlock : MonoBehaviour
{
    [SerializeField] private BoxCollider2D left;
    [SerializeField] private BoxCollider2D right;
    [SerializeField] private BoxCollider2D top;

    [SerializeField] public float speed;
    private Transform baddy;

    public float direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        speed = 3f;
        baddy = transform.GetComponent<Transform>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 move = new Vector3(direction, 0.0f, 0.0f);
        baddy.transform.position = baddy.transform.position + (move * (speed * Time.deltaTime));
    }
}
