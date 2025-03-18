using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    
    private GameObject projectile;
    public bool canShoot;


    //Testing for pausing
    private bool isPaused = false;

    private void OnEnable() { Messenger<bool>.AddListener(GameEvent.PAUSE_GAME, SetPausedState); }
    private void OnDisable() { Messenger<bool>.RemoveListener(GameEvent.PAUSE_GAME, SetPausedState); }

    /** 
    private void OnEnable() // Method for adding and removing listener
    {Messenger<bool>.AddListener(GameEvent.PAUSE_GAME, gameIsPaused);}
    private void OnDisable()
    {Messenger<bool>.RemoveListener(GameEvent.PAUSE_GAME, gameIsPaused);}
    */

    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Testing for paused state
        if (!isPaused && Input.GetMouseButtonDown(0) && canShoot)
        {
            projectile = Instantiate(projectilePrefab);
            projectile.GetComponent<GenericProjectile>().type = GenericProjectile.projectileType.Player;
            projectile.transform.position = transform.TransformPoint(Vector3.forward * 1f);
            projectile.transform.rotation = transform.rotation;
        }


        /**
        if (Input.GetMouseButtonDown(0) && canShoot)    // When mouse button clicked, creates a projectile; no shooting when a certain event disables it
        {
            projectile = Instantiate(projectilePrefab) as GameObject;   // spawn object

            projectile.GetComponent<GenericProjectile>().type = GenericProjectile.projectileType.Player;    // set projectile type

            projectile.transform.position = transform.TransformPoint(Vector3.forward * 1f);     // set object infront of cam
            projectile.transform.rotation = transform.rotation;
        }
        */
    }

    private void SetPausedState(bool state)
    {
        isPaused = state;
    }

    private void gameIsPaused(bool state)   // When game is paused, disable shooting
    {
        if(state == true)       // technically it can just be canShoot = !state but this was done to avoid confusion
            canShoot = false;
        else
            canShoot = true;
    }
}
