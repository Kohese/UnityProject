using UnityEngine;
using UnityEngine.Splines;

public class SplineCollideGenerator : MonoBehaviour
{
    public SplineContainer splineContainer;
    public GameObject colliderPrefab;
    public int segmentCount = 10;

    void Start()
    {
        GenerateColliders();
    }

    void GenerateColliders()
    {
        if (splineContainer == null || colliderPrefab == null) return;

        Spline spline = splineContainer.Spline;

        for (int i = 0; i <= segmentCount; i++)
        {
            float t = i / (float)segmentCount;
            Vector3 position = spline.EvaluatePosition(t);

            Debug.Log("Spawning object");

            GameObject colliderObject = Instantiate(colliderPrefab, position, Quaternion.identity);
            colliderObject.transform.parent = transform;
            
        }
    }
}

// using UnityEngine;

// public class SplineCollideGenerator : MonoBehaviour
// {
//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
