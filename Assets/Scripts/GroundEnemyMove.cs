using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemyMove : Move {

  private const float moveSpeed = 1.5f;
  public Transform baseTransform;

  private void OnTriggerStay2D(Collider2D collision) {
    Rigidbody2D me = GetComponentInParent<Rigidbody2D>();

    bool toMyLeft =
      collision.GetComponentInParent<SinglePlayerChar>().transform.position.x
      < me.transform.position.x;

    if(toMyLeft)
      baseTransform.localEulerAngles = new Vector3(0, 180, 0);
    else
      baseTransform.localEulerAngles = new Vector3(0, 0, 0);

    me.velocity = new Vector2(toMyLeft ? -moveSpeed : moveSpeed, 0);
  }
}
