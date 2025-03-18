using UnityEngine;
using UnityEngine.UIElements;
using TMPro;    // IMPORT This to use text
using Microlight.MicroBar;

public class HUD_HP_Controller : MonoBehaviour
{
    [SerializeField] TMP_Text hpLabel;   // Insert text UI element into here (via inspector) to display values using that UI text
    [SerializeField] 
    MicroBar bar;
    private int _hp; // Score variable
    private GameObject player;

    public void Open()
    {
        gameObject.SetActive(true);
        player = GameObject.Find("Player");
        
        _hp = player.GetComponent<PlayerHealth>().health; 
        hpLabel.text = _hp.ToString();    // Set score to 0 upon start
        bar.Initialize(10f);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    
    private void OnEnable() // Method for adding and removing listener
    {Messenger<int>.AddListener(GameEvent.UPDATE_HEALTH, updateHealth);}
    private void OnDisable()
    {Messenger<int>.RemoveListener(GameEvent.UPDATE_HEALTH, updateHealth);}

    private void updateHealth(int new_hp)
    {
        _hp = new_hp; 
        hpLabel.text = _hp.ToString();
        bar.UpdateBar(bar.CurrentValue - 1f);
    }
}

