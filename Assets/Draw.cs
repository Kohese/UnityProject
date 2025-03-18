using UnityEngine;

public class Draw : MonoBehaviour
{
    private float stopDistance = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * stopDistance, Color.red);
    }
}
