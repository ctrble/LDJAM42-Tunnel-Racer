using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

  public Rigidbody playerRB;
  public float targetTime = 1f;
  Vector3 lookDirection = Vector3.zero;
  public int speed = 10;
  public float currentLookSpeed = 0f;
  public int maxLookSpeed = 2;
  public int acceleration = 10;
  public int rotation = 10;
  public bool thrust;
  public bool brake;
  public bool up;
  public bool down;
  public bool left;
  public bool right;
  public bool clockwise;
  public bool counterClockwise;

  void OnEnable() {
    if (playerRB == null) {
      playerRB = GetComponent<Rigidbody>();
    }

    currentLookSpeed = 0;
    lookDirection = Vector3.zero;
  }

  void Update() {

    GetInput();


    if (currentLookSpeed <= maxLookSpeed) {

      currentLookSpeed += (Time.deltaTime * 0.5f);

    }

  }

  void FixedUpdate() {
    HandleInput();
    playerRB.AddForce(-Vector3.up * acceleration * Time.deltaTime, ForceMode.Acceleration);
    playerRB.AddRelativeForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
  }

  void GetInput() {

    if (Input.GetKey("space")) {
      thrust = true;
    }
    else {
      thrust = false;
    }

    if (Input.GetKey("left shift")) {
      brake = true;
    }
    else {
      brake = false;
    }

    if (Input.GetKey("w")) {
      up = true;
    }
    else {
      up = false;
    }

    if (Input.GetKey("s")) {
      down = true;
    }
    else {
      down = false;
    }

    if (Input.GetKey("d")) {
      right = true;
    }
    else {
      right = false;
    }

    if (Input.GetKey("a")) {
      left = true;
    }
    else {
      left = false;
    }

    if (Input.GetKey("e")) {
      clockwise = true;
    }
    else {
      clockwise = false;
    }

    if (Input.GetKey("q")) {
      counterClockwise = true;
    }
    else {
      counterClockwise = false;
    }
  }

  void HandleInput() {

    // mouse
    lookDirection = new Vector3(-Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), 0);
    playerRB.AddRelativeTorque(lookDirection * currentLookSpeed * Time.deltaTime);

    if (thrust) {
      playerRB.AddRelativeForce(Vector3.forward * speed * Time.deltaTime, ForceMode.Impulse);
    }

    if (brake) {
      playerRB.AddRelativeForce(-Vector3.forward * speed * 0.66f * Time.deltaTime, ForceMode.Impulse);
    }

    if (up) {
      playerRB.AddRelativeForce(Vector3.up * speed * Time.deltaTime, ForceMode.Impulse);
    }

    if (down) {
      playerRB.AddRelativeForce(-Vector3.up * speed * Time.deltaTime, ForceMode.Impulse);
    }

    if (right) {
      playerRB.AddRelativeForce(Vector3.right * speed * Time.deltaTime, ForceMode.Impulse);
    }

    if (left) {
      playerRB.AddRelativeForce(-Vector3.right * speed * Time.deltaTime, ForceMode.Impulse);
    }

    if (clockwise) {
      playerRB.AddRelativeTorque(Vector3.forward * rotation * Time.deltaTime);
    }

    if (counterClockwise) {
      playerRB.AddRelativeTorque(-Vector3.forward * rotation * Time.deltaTime);
    }

  }
}
