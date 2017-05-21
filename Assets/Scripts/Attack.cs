using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

  public int damage;

  private void OnTriggerEnter2D(Collider2D collision) {
    Character character = collision.GetComponentInParent<Character>();
    character.takeDamage(damage, this.GetComponentInParent<Transform>().position.x);
  }
}
