using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

  private void OnTriggerEnter2D(Collider2D collision) {
    Character character = collision.GetComponentInParent<Character>();
    character.takeDamage(10);
  }

}
