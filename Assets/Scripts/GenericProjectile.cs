// using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class GenericProjectile : MonoBehaviour
{
    // Projectile can be set a type, so i don't have to make duplicate projectile prefabs for player and enemy
    // I guess technically this should be on a parent class and projectiles with unique trajectory code inherit the parent but eh
    public enum projectileType {    
        Player = 0, // Hurts enemies and other target types
        Enemy = 1,  //Hurts player
    }
    public projectileType type;     // initalize universal variables
    public int damage = 1;
    public float despawnTime = 10.0f;
    public float timer = 0.0f;
    public float velocity = 12f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;    // Increase timer
        // Debug.Log(timer);

        trajectory();   //  Trajectory function depends on each instance type of the class

        despawnTime -= Time.deltaTime;  // If a certain time has passed, destroy object
        if (despawnTime <= 0)
        {Destroy(gameObject);}

    }

    private void OnTriggerEnter(Collider other) {   // upon collision -> do damage, then despawn
        if (other.CompareTag("Train") || other.CompareTag("Door"))  // phase through train and door
            return;
        
        if (other.TryGetComponent(out DamageableBase hit))    // Get component and check projectile type and target type to avoid self damage
        {
            Debug.Log("Damageable");
            if (other.CompareTag("Player") && type  == projectileType.Enemy)         // Enemy projectile damages player
            {   Debug.Log(other.CompareTag("Player"));
                hit.TakeDamage(damage);}
            
            if (!other.CompareTag("Player") && type == projectileType.Player)  // Player projectile damages enemy/target
            {   Debug.Log(!other.CompareTag("Player"));
                hit.TakeDamage(damage);}
        }
                
        Destroy(gameObject);
        
    }

    public virtual void trajectory()
    {

    }
}
