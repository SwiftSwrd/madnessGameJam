using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

  private const float knockbackUpVel = .5f;
  private const float knockbackBackVel = 1f;

  public int maxHealth;
  private int currentHealth;

  // Use this for initialization
  void Start () {
  	
  }

  // Update is called once per frame
  void Update () {
  	
  }

  public override void takeDamage(int damage, float damageSourceX) {
    Vector2 knockbackVector;

    currentHealth -= damage;

    if (0 >= currentHealth)
      Destroy(this);

    knockbackVector = new Vector2((transform.position.x < damageSourceX)
      ? -knockbackBackVel : knockbackBackVel, knockbackUpVel);

    GetComponent<Rigidbody2D>().velocity = knockbackVector;
  }

  public void blocked(float playerX) {
    GetComponent<Rigidbody2D>().velocity = new Vector2(
      (transform.position.x < playerX)
      ? -knockbackBackVel*4 : knockbackBackVel*4, knockbackUpVel*2);
  }
}
