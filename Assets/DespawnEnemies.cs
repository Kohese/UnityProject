using UnityEngine;

public class DespawnEnemies : MonoBehaviour
{
    private GameObject parent;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrainController") || other.CompareTag("Train"))
        {
            GetChild();
            GameObject spawner = GameObject.FindWithTag("Spawner");
            spawner.GetComponent<SpawnController>().enabled = true;
            spawner.GetComponent<GenerateKey>().enabled = true;
        }
    }

    void GetChild()
    {
    parent = GameObject.FindWithTag("EnemyParent");
    int childCount = parent.transform.childCount;


    for (int i = 0; i < childCount; i++)
    {
        Destroy(parent.transform.GetChild(i).gameObject);
    }
    }
}
