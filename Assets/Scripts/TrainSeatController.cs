using UnityEngine;
using TMPro;

public class TrainSeatController : MonoBehaviour
{

    public Transform carseat;
    private Vector3 InitialPos;
    private Quaternion InitialRot;

    public GameObject player;
    public Transform train;

    public TMP_Text pressEText; //What we drag the E button into

    public float distance = 3f;

    private bool range = false;
    public bool inCart = false;
    public float distanceFromTrain = 5f;
    public float heightOffset = 100f;

    

     private CharacterController playerController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = player.GetComponent<CharacterController>();

        pressEText.gameObject.SetActive(false); //Just to make sure it's disabled

    }

    // Update is called once per frame
    void Update()
    {

        if (inCart) {
            InitialPos.z = train.position.z + heightOffset * 16;
            InitialPos.x = train.position.x + heightOffset * 8;
            InitialPos.y = train.position.y + heightOffset * 8;

        }
        // if the player is in range and not in the car and presses e, enter the cart
        if (range && !inCart)
        {
            //Makes UI prompt appear when in range
            pressEText.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                // set the player in cart boolean to  true
                inCart = true;

                // Get current character position + rotation
                InitialPos = player.transform.position;
                InitialRot = player.transform.rotation;

                // set the player position to the carseat
                player.transform.position = carseat.position;

                // make the player a child of the cart so that they will move with it
                player.transform.SetParent(transform);

                // Disable player movement while in the cart
                if (playerController != null)
                {
                    playerController.enabled = false;  // Assuming PlayerController controls movement
                }

                pressEText.gameObject.SetActive(false); //So the prompt is hidden when inside the train
            }
        } 
        else if (inCart && Input.GetKeyDown(KeyCode.E))
        {
            //Set play in car boolean to false
            inCart = false;

            //Removes the player as a child from the cart
            player.transform.SetParent(null);

            //Puts the player back to where they were
            player.transform.position = InitialPos;
            player.transform.rotation = InitialRot;


            if (playerController != null)
            {
                playerController.enabled = true;
            }


            if (!inCart && range)
            {
                range = false;
            }

        }

            //So there's no prompt if you're not in range
            if (!range)
            {
                pressEText.gameObject.SetActive(false);
            }

    }

    void OnTriggerEnter(Collider other) {
        // if the colliding object has the player tag, then the player is in range
        if (other.CompareTag("Player")) {
            range = true;
        }
    }

    void OnTriggerExit(Collider other) {
        // when player is no longer in range
        if (other.CompareTag("Player")) {
            range = false;
            pressEText.gameObject.SetActive(false);
        }
    }
}
