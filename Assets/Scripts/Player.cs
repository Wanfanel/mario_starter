using UnityEngine;


public class Player : MonoBehaviour
{

    // variables taken from CharacterController.Move example script
    // https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private static GameObject playerObject;

    public static int Lives = 3; // number of lives the player hs


    static Vector3 start_position; // start position of the player


    void Start()
    {
        // record the start position of the player
        start_position = transform.position;
        GetPlayerObject();
    }

    public static void Reset()
    {
        // reset the player position to the start position
        playerObject.transform.position = start_position;
    }

    public static GameObject GetPlayerObject()
    {
        if (playerObject)
            return playerObject;
        else
            playerObject = GameObject.FindGameObjectWithTag("Player");
        return playerObject;
    }

    void Update()
    {
        // get the character controller attached to the player game object
        CharacterController controller = GetComponent<CharacterController>();


        // check to see if the player is on the ground
        if (controller.isGrounded)
        {
            // set the movement direction based on user input and the desired speed
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            // check to see if the player should jump
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }

        // apply gravity to movement direction
        moveDirection.y -= gravity * Time.deltaTime;

        // make the call to move the character controller
        controller.Move(moveDirection * Time.deltaTime);
    }
}
