using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

  public GameObject lightChar;

	// Use this for initialization
	void Start () {
    Camera.main.aspect = 16f/9f;
    //Camera.main.orthographicSize = (1.54f * (Screen.height / Screen.width));
  }

  void Update() {
    Vector3 pos = lightChar.transform.position;
    pos.y += 4.5f;
    pos.z = -1;
    transform.position = pos;
  }
}
