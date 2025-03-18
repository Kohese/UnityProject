using UnityEngine;
using UnityEngine.AI;

public class MovingOnMesh : MonoBehaviour
{
    public float checkRadius = 1.0f;  // Small radius for checking
    private bool isOnNavMesh;

        // public NavMeshSurface surface;  // Assign this in the Inspector

    // void Start()
    // {
    //     if (surface != null)
    //     {
    //         surface.BuildNavMesh();  // Ensure the NavMesh is built if dynamic
    //     }
    // }

    void Update()
    {
        isOnNavMesh = CheckIfOnNavMesh(transform.position);
        
        if (isOnNavMesh)
        {
            Debug.Log("Player/Train is on the NavMesh!");
        }
        else
        {
            Debug.Log("Player/Train is NOT on the NavMesh!");
        }
    }

    bool CheckIfOnNavMesh(Vector3 position)
    {
        NavMeshHit hit;
        return NavMesh.SamplePosition(position, out hit, checkRadius, NavMesh.AllAreas);
    }
}
