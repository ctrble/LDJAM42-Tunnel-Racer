using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path_Light : MonoBehaviour {

  public Transform player;
  public int distance;

  void Update() {
    transform.position = new Vector3(0, player.transform.position.y - distance, 0);
  }
}
