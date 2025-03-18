using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    private Transform player;

    //Stuff for the noise
    [SerializeField] private AudioClip playerHurt;
    private AudioSource audioSource;

    [SerializeField]
    private Image[] hearts;

    public bool heaaaaa = false;

    [SerializeField]
    private Sprite fullHealth;

    [SerializeField]
    private Sprite brokenHealth; 

    [SerializeField]
    private Sprite emptyHealth;
    private int health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = hearts.Length * 2;
        Debug.Log(player);
        HealthUpdate();

        //Getting audio source for player
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage();
        }
    }


 // Update is called once per frame
    void TakeDamage()
    {
        if (health > 0)
        {
            health--;
            HealthUpdate();
            audioSource.clip = playerHurt;
            audioSource.Play();
        }

        if (health <= 0)
        {
            Debug.Log("Player is dead");
        }
    }

    void HealthUpdate()
    {

        for (int i = 0; i < hearts.Length; i++)
        {
            Debug.Log(hearts.Length);
            int HeartState = Mathf.Clamp(health - (i * 2), 0, 2);
            Debug.Log(HeartState);

            switch(HeartState)
            {
                case 2:
                    hearts[i].sprite = fullHealth;
                    break;
                case 1:
                    hearts[i].sprite = brokenHealth;
                    break;
                case 0:
                    hearts[i].sprite = emptyHealth;
                    break;
            }
        }
    }
}
