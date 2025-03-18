

using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class SpawnController : MonoBehaviour
{
    public GameObject[] enemyPrefab;       // The enemy prefab to spawn
    public GameObject parent;
    public float spawnRadius = 10f;        // Radius around the spawn point to pick a random position
    public int maxEnemies = 14;            // Maximum number of enemies to spawn
    public Transform spawnPoint;           // The point where the enemies will spawn from
    public float minSpawnDistance = 3f;    // Minimum distance between enemies

    private List<Vector3> spawnedPositions = new List<Vector3>(); // Track spawned positions

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            Vector3 spawnPosition = GetValidSpawnPosition();
            if (spawnPosition != Vector3.zero)
            {
                int randIdx = Random.Range(0, enemyPrefab.Length);
                GameObject enemy = Instantiate(enemyPrefab[randIdx], spawnPosition, Quaternion.identity);
                spawnedPositions.Add(spawnPosition); // Store position to prevent overlap
                enemy.transform.SetParent(parent.transform);
                enemy.tag = "enemy";
            }
        }
    }

    Vector3 GetValidSpawnPosition()
    {
        int attempts = 10; // Have a set number of attempts so that it doesn't infiinite loop
        while (attempts > 0)
        {
            Vector3 potentialPosition = GetRandomNavMeshPosition();
            if (potentialPosition != Vector3.zero && IsFarEnoughFromOthers(potentialPosition))
            {
                return potentialPosition;
            }
            attempts--;
        }
        return Vector3.zero; // Return zero if no valid position is found
    }

    Vector3 GetRandomNavMeshPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * spawnRadius;
        randomDirection += spawnPoint.position;
        NavMeshHit hit;
        
        if (NavMesh.SamplePosition(randomDirection, out hit, spawnRadius, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return Vector3.zero;
    }

    bool IsFarEnoughFromOthers(Vector3 position)
    {
        foreach (Vector3 spawned in spawnedPositions)
        {
            if (Vector3.Distance(position, spawned) < minSpawnDistance)
            {
                return false; // Too close to another enemy
            }
        }
        return true;
    }
}