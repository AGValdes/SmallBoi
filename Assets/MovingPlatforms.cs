using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
  private Vector3 posA;
  private Vector3 posB;
  private Vector3 nextPos;
  [SerializeField]
  private float speed;
  [SerializeField]
  private Transform movingPlatform;
  [SerializeField]
  private Transform pivot;
  private void Start()
  {
    posA = movingPlatform.localPosition;
    posB = pivot.localPosition;
    nextPos = posB;
    speed = 1.3f;
  }
  private void Update()
  {
    Move();
  }
  private void Move()
  {
    movingPlatform.localPosition = Vector3.MoveTowards(
        movingPlatform.localPosition, nextPos, speed * Time.deltaTime);
    if (Vector3.Distance(movingPlatform.localPosition, nextPos) <= 0.1)
      ChangeDirection();
  }
  private void ChangeDirection()
  {
    nextPos = nextPos != posA ? posA : posB;
  }
}
