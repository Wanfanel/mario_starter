using UnityEngine;


public class Enemy : MonoBehaviour
{

    // variables taken from CharacterController.Move example script
    // https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    public Vector3 direction = Vector3.right; //  direction the enemy will move in
    Vector3 start_position = Vector3.zero; // start position of the enemy
    Vector3 start_direction; // start direction of the enemy

    void Start()
    {
        // get the character controller attached to the enemy game object ()
        controller = GetComponent<CharacterController>();

        // record the start position
        start_position = transform.position;

        // record the start direction
        start_direction = direction;
    }

    public void Reset()
    {
        // reset the enemy position to the start position. Cannot transform with no Physics.SyncTransforms()
        Physics.SyncTransforms();
        transform.position = start_position;

        // reset the movement direction
        direction = start_direction;
    
    }

    void FixedUpdate()
    {
        // check to see if the enemy is on the ground
        if (controller.isGrounded)
        {
            // set character controller moveDirection to be the direction I want the enemy to move in
            moveDirection = direction * speed;

        }


        // apply gravity to movement direction
        moveDirection.y -= gravity * Time.fixedDeltaTime;

        // make the call to move the character controller
        controller.Move(moveDirection * Time.fixedDeltaTime);
    }

    //
    // This function is called when a CharacterController moves into an object
    //
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // find out what we've hit
        if (hit.collider.GetComponent<Player>())
        {
            // we've hit the player

          
            // remove a life from the player
            Player.Lives = Player.Lives - 1;
            // reset the enemy
            Reset();

            // reset the player
            Player.Reset();
            
        }
        else
        {
            // We hit objects below us
            if (hit.moveDirection.y < -0.3f)
                return;

            // flip the direction of the enemy
            direction = -direction;
        }
    }
}
