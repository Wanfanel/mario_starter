using UnityEngine;


public class GameLogic : MonoBehaviour {

	Player playerComponent;

	public bool gameOver = false; // is the game over?

	// Update is called once per frame
	void Update () {
		// if the player number of lives is zero, game over
		if (Player.Lives == 0) {
			gameOver = true;

			// pause the game
			Time.timeScale = 0.0f;
		}
	}
}
