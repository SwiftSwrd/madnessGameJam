using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

  public abstract void takeDamage(int damage, float damageSourceX);
  public abstract void knockback(float from);
}
