using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	// the following variables need connected up in the editor inspector
	public Text livesText; // text object to display the number of lives
	public Text gameOverText; // text object to display game over message



	
	// Update is called once per frame
	void FixedUpdate () {

		// update the display for the player's number of lives
		livesText.text = "Lives: "+Player.Lives;

		// if game over, then display game over text
		if (GameLogic.gameOver == true) {
			gameOverText.gameObject.SetActive (true);
		}
	}
}
