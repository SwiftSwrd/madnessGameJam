using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour {

  public Player player;

  private void OnTriggerEnter2D(Collider2D collision) {
    player.setAnimatorBools("isJumping", false);
  }

  //private void OnTriggerExit2D(Collider2D collision) {
  //  parent.animator.SetBool("isJumping", true);
  //}
}
