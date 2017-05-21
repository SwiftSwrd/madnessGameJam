using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerChar : MonoBehaviour {

  public BoxCollider2D myHurtbox;
  public BoxCollider2D myHitbox;

  private Vector2 hurtboxSize;
  private Vector2 hitboxSize;

  private void Start() {
    hurtboxSize = myHurtbox.size;
    hitboxSize = myHitbox.size;
    myHitbox.size = new Vector2(0, 0);
  }

  public void attack(bool inElement) {
    if (inElement)
      myHitbox.size = hitboxSize;
  }

  public void resetHitbox() {
    myHitbox.size = new Vector2(0, 0);
  }

  public void tookDamage() {
    myHurtbox.size = new Vector2(0, 0);
  }

  public void resetHurtbox() {
    myHurtbox.size = hurtboxSize;
  }
}
