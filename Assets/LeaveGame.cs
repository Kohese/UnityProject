using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveGame : MonoBehaviour
{
    public GenerateKey keyBool;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && keyBool.playerHasKey)
        {
            Debug.Log("Player has now left the game");
            Messenger.Broadcast(GameEvent.RESULT_SCREEN);
            Messenger<bool>.Broadcast(GameEvent.PAUSE_GAME, true);
            // SceneManager.LoadScene("End Screen");
        }

        if (other.CompareTag("Player") && !keyBool.playerHasKey)
        {
            Debug.Log("Player is missing the key");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(keyBool);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
