using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("Player")) {

      Debug.Log("hit player!");
      collision.gameObject.SetActive(false);
    }
  }
}
