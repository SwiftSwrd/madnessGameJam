﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

  // Use this for initialization
  void Start () {
  	
  }

  // Update is called once per frame
  void Update () {
  	
  }

  public override void takeDamage(int damage) {
    //Apply Damage, brief stun + invuln
    throw new NotImplementedException();
  }
}
