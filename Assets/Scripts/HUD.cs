using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    // the following variables need connected up in the editor inspector
    public Text livesText; // text object to display the number of lives
    public Text gameOverText; // text object to display game over message


    private void Update()
    {
        // if game over, then display game over text
        if (GameLogic.gameOver == true)
        {
            gameOverText.gameObject.SetActive(true);

            // allow reset scene
            if (Input.GetButton("Jump"))
            {
                GameLogic.GameReset();
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                gameOverText.gameObject.SetActive(false);
                
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // update the display for the player's number of lives
        livesText.text = "Lives: " + Player.Lives;

    }
}
