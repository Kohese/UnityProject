using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : DamageableBase
{
    //For SFX
    [SerializeField] AudioClip playerDamageSoundClip;
    private AudioSource audioSource;


    [SerializeField] GameObject menuPrefab;
    GameObject gameOverMenu;
    public int health;
    private bool invincible = false;

    public override void TakeDamage(int damage)
    {
        
        
        if (invincible == false)    // When i-frames inactive, take damage when hit
        {
            invincible = true;          // start i-frames and lower health
            Debug.Log("Took damage");
            health -= damage;

            SoundFXManager.instance.PlaySoundFXClip(playerDamageSoundClip, transform, 1f);
            
            Messenger<int>.Broadcast(GameEvent.UPDATE_HEALTH, health);
            Debug.Log(health);
        }
        Invoke(nameof(iframesDone), 1); // disable invinvibility frames after 1 sec

        if (health <= 0)    // when health is 0, pause game and show game over menu
        {
            Debug.Log("YOU ARE DEAD!");
            Messenger<bool>.Broadcast(GameEvent.PAUSE_GAME, true);
            gameOverMenu = Instantiate(menuPrefab);
            Time.timeScale = 0f;

        }
    }

    private void iframesDone()
    {
        invincible = false;
    }
}
