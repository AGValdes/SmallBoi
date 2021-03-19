using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveText : MonoBehaviour
{
    RectTransform canvas;
    RectTransform button;
    Vector3 startingPosition;
    public float speed;

    public void Start()
    {
        button = gameObject.GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas").GetComponent<RectTransform>();
        startingPosition = transform.position;
        //speed = .12f;
    }

    public void Update()
    {
        transform.Translate(0f, speed, 0f);
        if (button.position.y < -button.rect.height)
            transform.position = new Vector3(startingPosition.x, canvas.rect.height + button.rect.height, startingPosition.z);
    }
}
