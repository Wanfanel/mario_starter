using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	// the following variables need connected up in the editor inspector
	public Text livesText; // text object to display the number of lives
	public Text gameOverText; // text object to display game over message


	//Player playerComponent;
	GameLogic gameLogicComponent;

	// Use this for initialization
	void Start () {
		// find the GameLogic componet
		gameLogicComponent = FindObjectOfType<GameLogic> ();
	}
	
	// Update is called once per frame
	void Update () {

		// update the display for the player's number of lives
		livesText.text = "Lives: "+Player.Lives;

		// if game over, then display game over text
		if (gameLogicComponent.gameOver == true) {
			gameOverText.gameObject.SetActive (true);
		}
	}
}
