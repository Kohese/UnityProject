using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Train"))
        {
            Debug.Log($"{other.gameObject.name} entered {gameObject.name}");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Train"))
        {
            Debug.Log($"{other.gameObject.name} left {gameObject.name}");
        }
    }
}
