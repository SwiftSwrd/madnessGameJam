using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizFollow : MonoBehaviour {

  public GameObject lightChar;
  private float yDiff;
  private const float step = 0.125f;


  private void Start() {
    yDiff = transform.position.y - lightChar.transform.position.y;
  }

  void FixedUpdate() {
    float targetY = lightChar.transform.position.y + yDiff;
    float currY = transform.position.y;
    Vector3 pos = lightChar.transform.position;
    
    if(currY < targetY) {
      if (targetY - currY > step)
        pos.y = currY + step;
      else
        pos.y = targetY;
    }
    else if (currY > targetY) {
      if (currY - targetY > step)
        pos.y = currY - step;
      else
        pos.y = targetY;
    }
    else {
      pos.y = currY;
    }
      
    pos.z = 0;
    transform.position = pos;
  }
}
