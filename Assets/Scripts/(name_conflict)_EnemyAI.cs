using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate enemy to look at the player
        transform.LookAt(GameObject.FindWithTag("Player").transform.position);

        
    }
}
