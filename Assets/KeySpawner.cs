using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject key;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnKey();
    }

    void spawnKey()
    {
        int randomIdx = Random.Range(0, spawnPoints.Length);
        Instantiate(key, spawnPoints[randomIdx].position, key.transform.rotation);



        Debug.Log("key spawned: " + transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
