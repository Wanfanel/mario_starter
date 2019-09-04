using UnityEngine;


public class GameLogic : MonoBehaviour {


	public static bool gameOver = false; // is the game over?


    // remove a life from the player
    public static void LoseLive () {
        Player.Lives = Player.Lives - 1;
		// if the player number of lives is zero, game over
		if (Player.Lives == 0) {
			gameOver = true;

			// pause the game
			Time.timeScale = 0.0f;
		}
	}
}
