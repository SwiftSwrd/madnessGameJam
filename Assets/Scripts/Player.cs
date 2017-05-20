using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

  private const float DEADZONE = 0.4f;

  private bool right;
  private bool left;
  private bool up;
  private bool down;

  private bool aDown;
  private bool lDown;
  private bool rDown;

  // Use this for initialization
  void Start() {
  	
  }

  // Update is called once per frame
  void Update() {
  	
  }

  // FixedUpdate is called once per physics frame
  void FixedUpdate() {
    holdingUp();
    holdingDown();
    holdingRight();
    holdingLeft();
    buttonPressed("A", ref aDown);
    buttonPressed("L", ref lDown);
    buttonPressed("R", ref rDown);
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
}
