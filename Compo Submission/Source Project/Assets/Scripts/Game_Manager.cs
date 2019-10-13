using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour {

  public GameObject player;
  public Rigidbody playerRB;
  public Vector3 playerStartPosition = Vector3.zero;
  public Vector3 playerStartRotation = new Vector3(90, 0, 0);
  public GameObject gameOverText;
  public GameObject youWinText;
  private bool playerWins;

  void OnEnable() {
    ResetPlayer();
    gameOverText.SetActive(false);
    youWinText.SetActive(false);
    Cursor.visible = false;
  }

  void Update() {
    if (!player.activeInHierarchy && !playerWins) {
      gameOverText.SetActive(true);
    }

    else if (!player.activeInHierarchy && playerWins) {
      youWinText.SetActive(true);
    }

    if (gameOverText.activeInHierarchy && Input.GetKeyDown("r")) {
      ResetPlayer();
      gameOverText.SetActive(false);
    }

    else if (youWinText.activeInHierarchy && Input.GetKeyDown("r")) {
      ResetPlayer();
      youWinText.SetActive(false);
    }
  }

  void Win(bool wonGame) {
    if (wonGame) {
      playerWins = true;
      player.SetActive(false);
    }
  }

  void ResetPlayer() {
    playerWins = false;
    playerRB.isKinematic = true;
    player.transform.position = playerStartPosition;
    player.transform.rotation = Quaternion.Euler(playerStartRotation);
    playerRB.isKinematic = false;
    player.SetActive(true);
  }
}
