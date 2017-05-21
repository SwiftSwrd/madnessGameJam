using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

  public int damage;
  public Transform baseTransform;

  private void OnTriggerEnter2D(Collider2D collision) {
    Character target = collision.GetComponentInParent<Character>();
    Character me = GetComponentInParent<Character>();
    target.takeDamage(damage, baseTransform.position.x);
    if(me is Enemy)
      me.knockback(target.transform.position.x);
  }
}
