using UnityEngine;

public class FirstPerson : MonoBehaviour
{

    public TrainSeatController seatController;
    public float speed = 5f;
    public float gravity = -9.8f;

    private CharacterController characterController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        GameObject TrainseatObject = GameObject.Find("Project (Train)");

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        seatController = FindAnyObjectByType<TrainSeatController>();

        // Check if seatController was found
        if (TrainseatObject != null)
        {
            seatController = TrainseatObject.GetComponent<TrainSeatController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;


        // Store movement in a Vector3
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        // Clamp the vector so the player doesn't move too fast
        movement = Vector3.ClampMagnitude(movement, speed);

        // Apply gravity
        movement.y = gravity;

        // Multiply entire vector by time.deltatime
        movement *= Time.deltaTime;

        // Tansform movement from local to global coordinates
        movement = transform.TransformDirection(movement);

        // Move the character
        bool seatStatus = seatController.inCart;
        if (!seatStatus) {
        characterController.Move(movement);
        }


    }
}
