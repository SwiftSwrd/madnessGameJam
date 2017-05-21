using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : StateMachineBehaviour {

  private const float upwardVelocity = 7f;
  private const float horizontalVelocity = 1.5f;

  // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    Rigidbody2D jumpingPlayer = animator.GetComponentInParent<Rigidbody2D>();
    animator.SetBool("isJumping", true);
    jumpingPlayer.velocity = new Vector2(jumpingPlayer.velocity.x, upwardVelocity);
  }

  // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    Rigidbody2D jumpingPlayer = animator.GetComponentInParent<Rigidbody2D>();
    
    float xVel = 0;
    if (animator.GetBool("holdingRight"))
      xVel = horizontalVelocity;
    else if (animator.GetBool("holdingLeft"))
      xVel = -horizontalVelocity;
    
      jumpingPlayer.velocity = new Vector2(xVel, jumpingPlayer.velocity.y);
  }

  // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
  //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
  //
  //}

  // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
  //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
  //
  //}

  // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
  //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
  //
  //}
}
