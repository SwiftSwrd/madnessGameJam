using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : Enemy {

  private void Start() {
    super();
    knockbackUpVel = 1f;
    knockbackBackVel = 2f;
  }

}
