using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayerMove : MonoBehaviour
{
    public float speed = 12f;        // initalize movement speed and gravity
    public float gravity = -9.8f;

    public const float _baseSpeed =12f;
    private bool allowedToMove;    // Allows for player movement when on

    private CharacterController charController;    // initialize charcter controller component 
    private Camera cam;
    void Start()
    {
        charController = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
        allowedToMove = true;
    }

    void Update()   // Update is called once per frame
    {
        if (allowedToMove)
        {
            float deltaX = Input.GetAxis("Horizontal") * speed;    // get movement direction in X and Z axes
            float deltaZ = Input.GetAxis("Vertical") * speed;

            Vector3 movement = new Vector3(deltaX, 0, deltaZ);  // put movement directions into a Vector
            movement = cam.transform.TransformDirection(movement);  // Put X and Z movement relative to camera direction
            
            movement.y = gravity;   // apply gravity

            movement = Vector3.ClampMagnitude(movement, speed); // cap the movement speed
            movement *= Time.deltaTime; // make movement frame independent
            
            movement = transform.TransformDirection(movement); // convert the movement from local to global coordinates

            charController.Move(movement);  // move the character
        }
    }

    // Controls if player is allowed to move
    public void toggleMovement(bool state) {
        allowedToMove = state;
    }


}
