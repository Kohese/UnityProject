using UnityEngine;

public class Interactor : MonoBehaviour
{
    public LayerMask interactableLayermask = 8;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2, interactableLayermask))
        {
            Debug.Log(hit.collider.name);
        }
    }
}
