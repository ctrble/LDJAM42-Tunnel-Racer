using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe_End_Controller : MonoBehaviour {

  void OnTriggerEnter(Collider other) {

    Debug.Log(other.gameObject.name);

    if (other.gameObject.CompareTag("Player")) {
      other.transform.position = Vector3.zero;
    }
  }
}
