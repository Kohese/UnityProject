using UnityEngine;

public class FloatingProjectile : GenericProjectile
{
    // Update is called once per frame
    public override void trajectory()
    {
        Vector3 relativeMovement = new Vector3(0, 0, velocity);     // Forward movement relative to object
        relativeMovement *= Time.deltaTime;     // make movement frame independent
        transform.Translate(relativeMovement);  // actually move the projectile with the calculated values   
    }

    //     void OnTriggerEnter(Collider other)
    // {
    //     if (!other.CompareTag("Player")) return;
    //     // if (other.CompareTag("Entrance Room") || other.CompareTag("Hallway")) return;

    // }
}
