using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character {

  protected float knockbackUpVel;
  protected float knockbackBackVel;
  public BoxCollider2D myHurtbox;

  public int maxHealth;
  private int currentHealth;

  public Move movescript;

  protected void super() {
    currentHealth = maxHealth;
  }

  public override void takeDamage(int damage, float damageSourceX) {
    Debug.Log(currentHealth);

    currentHealth -= damage;

    Debug.Log(currentHealth);

    if (0 >= currentHealth)
      Destroy(gameObject);

    knockback(damageSourceX);
  }

  public override void knockback(float from) {
    Vector2 knockbackVector;
    movescript.enabled = false;
    myHurtbox.enabled = false;

    knockbackVector = new Vector2((transform.position.x < from)
      ? -knockbackBackVel : knockbackBackVel, knockbackUpVel);

    GetComponent<Rigidbody2D>().velocity = knockbackVector;
    StartCoroutine(deStagger());
  }

  private IEnumerator deStagger() {
    yield return new WaitForSeconds(1);
    GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
    movescript.enabled = true;
    myHurtbox.enabled = true;
  }

  public void blocked(float playerX) {
    knockbackBackVel *= 2;
    knockbackUpVel *= 2;

    knockback(playerX);

    knockbackBackVel /= 2;
    knockbackUpVel /= 2;
  }
}
