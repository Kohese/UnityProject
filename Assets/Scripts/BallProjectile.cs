using UnityEngine;

public class BallProjectile : GenericProjectile
{
    public float gravity = -9.8f;       // initalize variables

    // trajectory is a thrown ball affected by gravity
    //         void OnTriggerEnter(Collider other)
    // {
    //     if (!other.CompareTag("enemy")) return;
    //     // if (other.CompareTag("Entrance Room") || other.CompareTag("Hallway")) return;
    //     // if(other.CompareTag("enemy"))
    //     {

    //     }

    // }
    public override void trajectory()
    {
        Vector3 relativeMovement = new Vector3(0, 0, velocity);     // Forward movement relative to object
        Vector3 worldDown = new Vector3(0, gravity, 0);             // Downward movement relative to the world i.e. gravity

        worldDown.y *= timer;   // Acceleration due to gravity
        worldDown.y += velocity/6;  // Inital throw has slightly upward momentum

        Vector3 relativeDown = transform.InverseTransformDirection(worldDown);  // convert global downward direction into local direction 
        relativeMovement += relativeDown;   // apply downward movement due to gravity to local movement

        relativeMovement *= Time.deltaTime; // make movement frame independent

        transform.Translate(relativeMovement);  // actually move the projectile with the calculated values    
    }

}
