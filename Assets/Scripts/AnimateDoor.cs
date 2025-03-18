using UnityEngine;

public class AnimateDoor : MonoBehaviour
{
    public Animator doorAnim;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Train")) {
            doorAnim.SetTrigger("Open");
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Train")) {
            doorAnim.SetTrigger("Close");
        }
    }
}
