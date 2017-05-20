using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

  private const int MAX_HEALTH = 1000;
  private const float DEADZONE = 0.4f;

  public new GameObject light;
  public GameObject dark;
  public Animator animatorL;
  public Animator animatorD;

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

  private void face() {
    if(animators[0].GetBool("holdingRight")) {
      light.transform.localEulerAngles = new Vector3(0, 0, 0);
      dark.transform.localEulerAngles = new Vector3(0, 0, 0);
    }
    else if(animators[0].GetBool("holdingLeft")) {
      light.transform.localEulerAngles = new Vector3(0, 180, 0);
      dark.transform.localEulerAngles = new Vector3(0, 180, 0);
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

  public override void takeDamage(int damage) {
    currentHealth -= damage;
    healthBar.updateHealthDamage(currentHealth);
    
    if (0 >= currentHealth)
      Debug.Log("Dead");

    //Apply knocback
  }
}
