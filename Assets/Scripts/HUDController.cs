using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HUDController : MonoBehaviour
{
    [SerializeField] Score scoreHUD;
    [SerializeField] HUD_HP_Controller hpHUD;
    [SerializeField] ResultScreen resultScreen;

    public GameObject SettingsMenu;
    private void OnEnable() // Method for adding and removing listener
    {Messenger.AddListener(GameEvent.RESULT_SCREEN, showResults);}
    private void OnDisable()
    {Messenger.RemoveListener(GameEvent.RESULT_SCREEN, showResults);}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Debug.Log("START");
        resultScreen.Close();
        scoreHUD.Open();
        hpHUD.Open();
    }

    private void showResults()
    {
        scoreHUD.Close();
        hpHUD.Close();
        resultScreen.Open();
        
        DontDestroyOnLoad(gameObject);
    }

    public void OnExitBtn()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
        Destroy(gameObject);
    }
}
