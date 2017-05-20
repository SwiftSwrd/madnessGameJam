using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitializer : MonoBehaviour {

	// Use this for initialization
	void Start () {
    Camera.main.aspect = 16f/9f;
    //Camera.main.orthographicSize = (1.54f * (Screen.height / Screen.width));
  }
}
