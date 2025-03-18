using System.Collections;
using UnityEngine;

public class TargetReaction : MonoBehaviour
{
    // private bool isDying = false;

    // [SerializeField] GameObject hostTarget;
    private void OnTriggerEnter(Collider other)
    {
        GenericProjectile projectile = other.GetComponent<GenericProjectile>();    
        if (projectile != null)         // Check if it's hit by player's projectile to start death animation
        {
            Debug.Log("Target Reaction activated");
            Debug.Log(projectile.type);
            // StartCoroutine(death());
        }
    }

    // private IEnumerator death()     // Method for when target is dead
    // {
    //     if (isDying == false)   // check if dying hasn't started yet to prevent code executing again if already dying 
    //     {
    //         isDying = true;     // turn variable on to prevent future coroutines from starting this code again
    //         Messenger.Broadcast(GameEvent.INCREASE_SCORE);  // Adds point(s) to score
    //         transform.Rotate(-90,0,0);  // Rotate target as death animation
    //         yield return new WaitForSeconds(1.5f);  // wait for 1.5 seconds
    //         Destroy(gameObject);    // Unload target
    //     }
    // }


}
