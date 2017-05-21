using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSource : MonoBehaviour {

  public bool amLight;

  private void OnTriggerEnter2D(Collider2D collision) {
    Player player = collision.GetComponentInParent<Player>();
    if (amLight)
      player.setInLight(true);
    else
      player.setInShadow(true);
  }

  private void OnTriggerExit2D(Collider2D collision) {
    Player player = collision.GetComponentInParent<Player>();
    if (amLight)
      player.setInLight(false);
    else
      player.setInShadow(false);
  }
}
