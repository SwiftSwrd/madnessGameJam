using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyMove : Move {

  private const float speed = 0.025f;
  public Transform baseTransform;

  private void OnTriggerStay2D(Collider2D collision) {
    float realSpeed = speed * Time.deltaTime;
    if(collision.CompareTag(tag)) {
      baseTransform.position =
        Vector2.MoveTowards(transform.position, collision.transform.position, speed);
    }
  }
}
