using UnityEngine;

public class PauseController : MonoBehaviour
{
    private bool _isPaused = false;
    public GameObject settingsMenu; 

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        _isPaused = !_isPaused;
        Time.timeScale = _isPaused ? 0 : 1; 
        Messenger<bool>.Broadcast(GameEvent.PAUSE_GAME, _isPaused); 

        Cursor.lockState = _isPaused ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = _isPaused;

        if (settingsMenu != null)
        {
            settingsMenu.SetActive(_isPaused); 
        }
    }

    public void ResumeGame()
    {
        _isPaused = false;
        Time.timeScale = 1;
        Messenger<bool>.Broadcast(GameEvent.PAUSE_GAME, false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (settingsMenu != null)
        {
            settingsMenu.SetActive(false);
        }
    }
}
