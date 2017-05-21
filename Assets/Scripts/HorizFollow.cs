using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizFollow : MonoBehaviour {

  public GameObject lightChar;

  void Update() {
    Vector3 pos = lightChar.transform.position;
    pos.y = transform.position.y;
    pos.z = 0;
    transform.position = pos;
  }
}
