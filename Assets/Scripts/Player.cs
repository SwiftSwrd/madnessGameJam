using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

  private const int MAX_HEALTH = 1000;
  private const float DEADZONE = 0.4f;

  private const float knockbackUpVel = 1.5f;
  private const float knockbackBackVel = 3f;

  public GameObject lightChar, darkChar;
  public SinglePlayerChar lightScript, darkScript;
  public Animator animatorL, animatorD;

  public HealthBar healthBar;

  private int currentHealth;

  private bool right;
  private bool left;
  private bool up;
  private bool down;

  private bool aDown;
  private bool lDown;
  private bool rDown;

  private Animator[] animators;

  protected bool inShadow;
  protected bool inLight;

  // Use this for initialization
  void Start() {
    healthBar.initialize(MAX_HEALTH);
    currentHealth = MAX_HEALTH;
    animators = new Animator[2];
    animators[0] = animatorL;
    animators[1] = animatorD;
  }

  // Update is called once per frame
  void Update() {
  	
  }

  // FixedUpdate is called once per physics frame
  void FixedUpdate() {
    setAnimatorBools("holdingUp", holdingUp());
    setAnimatorBools("holdingDown", holdingDown());
    setAnimatorBools("holdingRight", holdingRight());
    setAnimatorBools("holdingLeft", holdingLeft());
    setAnimatorBools("aPressed", buttonPressed("A", ref aDown));
    setAnimatorBools("lPressed", buttonPressed("L", ref lDown));
    setAnimatorBools("rPressed", buttonPressed("R", ref rDown));
    face();
  }

  public void setAnimatorBools(String boolName, bool val) {
    foreach (Animator ani in animators)
      ani.SetBool(boolName, val);
  }

  public void setAnimatorTriggers(String trigName) {
    foreach (Animator ani in animators)
      ani.SetTrigger(trigName);
  }

  private void face() {
    if(animatorL.GetBool("holdingRight")) {
      lightChar.transform.localEulerAngles = new Vector3(0, 0, 0);
      darkChar.transform.localEulerAngles = new Vector3(0, 0, 0);
    }
    else if(animatorL.GetBool("holdingLeft")) {
      lightChar.transform.localEulerAngles = new Vector3(0, 180, 0);
      darkChar.transform.localEulerAngles = new Vector3(0, 180, 0);
    }
  }

  private bool holdingUp() {
    up = DEADZONE < Input.GetAxis("Vertical");
    return up;
  }

  private bool holdingDown() {
    down = -DEADZONE > Input.GetAxis("Vertical");
    return down;
  }

  private bool holdingRight() {
    right = DEADZONE < Input.GetAxis("Horizontal");
    return right;
  }

  private bool holdingLeft() {
    left = -DEADZONE > Input.GetAxis("Horizontal");
    return left;
  }

  private bool buttonPressed(string name, ref bool heldDown) {
    if (1 == Input.GetAxisRaw(name)) {
      if (true == heldDown)
        return false;
      else {
        heldDown = true;
        return true;
      }
    }
    else {
      if (true == heldDown)
        heldDown = false;
      return false;
    }
  }

  public override void takeDamage(int damage, float damageSourceX) {
    if (animatorL.GetBool("blocking"))
      block(damage);
    else
      hit(damage, damageSourceX);
  }

  private void block(int damage) {
    currentHealth -= damage/2;
    healthBar.updateHealthDamage(currentHealth);

    if (0 >= currentHealth)
      setAnimatorTriggers("dead");
  }

  private void hit(int damage, float damageSourceX) {
    Vector2 knockbackVector;

    currentHealth -= damage;
    healthBar.updateHealthDamage(currentHealth);

    if (0 >= currentHealth)
      setAnimatorTriggers("dead");
    else
      setAnimatorTriggers("hit");

    knockbackVector = new Vector2( (lightChar.transform.position.x < damageSourceX)
      ? -knockbackBackVel : knockbackBackVel, knockbackUpVel );

    lightChar.GetComponent<Rigidbody2D>().velocity = knockbackVector;
    darkChar.GetComponent<Rigidbody2D>().velocity = knockbackVector;
  }

  public void attack() {
    lightScript.attack(inLight);
    darkScript.attack(inShadow);
  }

  public void setInLight(bool inLight) {
    this.inLight = inLight;
  }

  public void setInShadow(bool inShadow) {
    this.inShadow = inShadow;
  }
}
