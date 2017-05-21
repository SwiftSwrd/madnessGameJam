using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : Enemy {

  private void Start() {
    super();
    knockbackUpVel = 1.5f;
    knockbackBackVel = 4f;
  }

}
