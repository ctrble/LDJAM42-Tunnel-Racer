using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

  public float secondsRemaining = 30f;
  public Text distanceUI;
  public Transform player;
  public Transform endPoint;

  void Update() {

    float distance = player.position.y - endPoint.position.y;
    distanceUI.text = "Distance: " + Mathf.RoundToInt(distance);

    if (distance <= 0) {
      distanceUI.text = "";
    }

    if (distance <= -15) {
      gameObject.SendMessageUpwards("Win", true);
    }
  }

}
