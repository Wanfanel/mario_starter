﻿using UnityEngine;


public class Player : MonoBehaviour
{

    // variables taken from CharacterController.Move example script
    // https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public Vector3 moveDirection = Vector3.zero;
    private static GameObject playerObject;
    CharacterController controller;

    public static int Lives = 3; // number of lives the player hs


    static Vector3 start_position; // start position of the player


    void Start()
    {
        // record the start position of the player
        start_position = transform.position;
        GetPlayerObject();
        // get the character controller attached to the player game object
        controller = GetComponent<CharacterController>();
        
    }
    
  

    public static void Reset()
    {
        // reset the player position to the start position
        Physics.SyncTransforms(); // fix https://issuetracker.unity3d.com/issues/charactercontroller-overrides-objects-position-when-teleporting-with-transform-dot-position
        playerObject.transform.position = start_position;
        playerObject.GetComponent<Player>().moveDirection = new Vector3(0, 0, 0); // reset movement

    }

    public static GameObject GetPlayerObject()
    {
        if (playerObject)
            return playerObject;
        else
            playerObject = GameObject.FindGameObjectWithTag("Player");
        return playerObject;
    }

    void FixedUpdate()
    {

        // check to see if the player is on the ground
        if (controller.isGrounded)
        {
            // set the movement direction based on user input and the desired speed
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0) * speed;

            // check to see if the player should jump
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }

        // apply gravity to movement direction
        moveDirection.y -= gravity * Time.fixedDeltaTime;

        // make the call to move the character controller
        controller.Move(moveDirection * Time.fixedDeltaTime);
    }
}