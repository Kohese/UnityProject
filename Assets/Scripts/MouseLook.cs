using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public enum RotationAxes {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXandY;

    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45f;
    public float maximumVert = 45f;

    private float verticalRot = 0f;

    bool mouseIsHidden;


    //Testing for pausing, remove if buns
    private bool isPaused = false;

    private void OnEnable() { Messenger<bool>.AddListener(GameEvent.PAUSE_GAME, SetPausedState); }
    private void OnDisable() { Messenger<bool>.RemoveListener(GameEvent.PAUSE_GAME, SetPausedState); }

    /** private void OnEnable() // Method for adding and removing listener
    {Messenger<bool>.AddListener(GameEvent.PAUSE_GAME, revealMouse);}
    private void OnDisable()
    {Messenger<bool>.RemoveListener(GameEvent.PAUSE_GAME, revealMouse);}
    */

    void Start()
    {
        revealMouse(false);
    }
    
    // Update is called once per frame
    void Update()
    {


        /** if (mouseIsHidden == true)
        {
            moveMouse();
        }
        */

        //Used for pausing, remove if buns
        if (!isPaused && mouseIsHidden) 
        {
            moveMouse();
        }
    }

    //Function for pausing
    private void SetPausedState(bool state)
    {
        isPaused = state;
        revealMouse(state); 
    }

    private void moveMouse()    // code for looking around
    {
        if (axes == RotationAxes.MouseX) {
            // Horizontal rotation
            transform.Rotate(0, sensitivityHor * Input.GetAxis("Mouse X"), 0);
        } else if (axes == RotationAxes.MouseY) {
            // Vertical rotation
            // transform.Rotate(sensitivityVert * Input.GetAxis("Mouse Y"), 0, 0);
            verticalRot -= sensitivityVert * Input.GetAxis("Mouse Y");
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float horizontalRot = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);

        } else {
            // Horizontal and Vertical rotation
            verticalRot -= sensitivityVert * Input.GetAxis("Mouse Y");
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float delta = sensitivityHor * Input.GetAxis("Mouse X");
            float horizontalRot = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
    }

    private void revealMouse(bool state)  // hide mouse if game is not paused, reveal mouse when game is paused
    {
        if (state == false)
        {
            Cursor.lockState = CursorLockMode.Locked;   // Hide and lock mouse cursor
            Cursor.visible = false;
            mouseIsHidden = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;   // Show and unlock mouse cursor
            Cursor.visible = true;
            mouseIsHidden = false;
        }
    }
}
