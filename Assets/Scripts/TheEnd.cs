using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheEnd : MonoBehaviour {

  private void OnTriggerEnter2D(Collider2D collision) {
    Application.LoadLevel(0);
  }

}
