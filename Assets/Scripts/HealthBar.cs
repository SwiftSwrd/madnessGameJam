using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

  public Slider myHealthSlider;
  public Slider myDamageSlider;

  private int maxHealth;

  private float prevHealthWindow = 1.25f;

  private IEnumerator currentDamageRoutine = null;

  public void initialize(int maxHealth) {
    this.maxHealth = maxHealth;
  }

  public void resetHealth() {
    myHealthSlider.value = 1;
    myDamageSlider.value = 1;
  }

  public void updateHealthDamage(int newHealth) {
    myHealthSlider.value = ((float)newHealth / (float)maxHealth);
    //Null used as flag to indicate if coroutine is running
    if(null !=currentDamageRoutine)
      StopCoroutine(currentDamageRoutine);
    currentDamageRoutine = changeDamageSlider(newHealth);
    StartCoroutine(currentDamageRoutine);
  }

  private IEnumerator changeDamageSlider(int newHealth) {
    yield return new WaitForSeconds(prevHealthWindow);
    myDamageSlider.value = (float)newHealth / (float)maxHealth;
    //Indicate that the routine is not running
    currentDamageRoutine = null;
  }
}
