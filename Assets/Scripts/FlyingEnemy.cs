using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy {

  private void Start() {
    super();
    knockbackUpVel = 0.5f;
    knockbackBackVel = 4f;
  }

}
