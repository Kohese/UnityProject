using UnityEngine;

public class MenuCameraController : MonoBehaviour
{
    public Transform[] waypoints;  
    public float speed = 2f;       
    private int currentIndex = 0;  

    private void Start()
    {
        if (waypoints.Length < 2)
        {
            Debug.LogError("You need at least 2 waypoints!");
        }
    }

    void Update()
    {
        if (waypoints.Length < 2) return;

        Transform target = waypoints[currentIndex + 1]; 

        
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            
            currentIndex += 2;

            
            if (currentIndex >= waypoints.Length - 1)
            {
                currentIndex = 0;  
            }

            
            transform.position = waypoints[currentIndex].position;
        }
    }
}
