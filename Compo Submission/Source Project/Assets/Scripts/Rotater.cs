using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {

  public int rotationAmount = 10;

  void Update() {

    transform.RotateAround(Vector3.zero, Vector3.up, rotationAmount * Time.deltaTime);

  }
}
