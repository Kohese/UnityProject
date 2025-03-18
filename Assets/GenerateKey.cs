using UnityEngine;
using System.Collections;


public class GenerateKey : MonoBehaviour
{
    public GameObject parent;
    public GameObject selectedEnemy;
    private GameObject[] children;
    private int childCount;
    private bool hasRun = false;
    public bool playerHasKey = false;
    [SerializeField]
    private Animator keyAnimator;
    
    void GetChild()
    {
        // function to get all children from parent
    int childCount = parent.transform.childCount;
    children = new GameObject[childCount];

    for (int i = 0; i < childCount; i++)
    {
        children[i] = parent.transform.GetChild(i).gameObject;
    }
    
        int GetRandomIdx = Random.Range(0, children.Length);
        Debug.Log($"Random index: {children.Length}");
        selectedEnemy = parent.transform.GetChild(GetRandomIdx).gameObject;

        if (selectedEnemy.GetComponent<Light>() == null)
            selectedEnemy.AddComponent<Light>();
        
        GameObject particles = GameObject.FindWithTag("Particles");
        particles.transform.SetParent(selectedEnemy.transform);
        particles.transform.position = selectedEnemy.transform.position;

    }

        // Coroutine to start the animator and stop it after 2 seconds
    public IEnumerator StartAndStopAnimator()
    {
        keyAnimator.SetTrigger("Open"); // Set the trigger or bool to start the animation

        yield return new WaitForSeconds(2f); // Wait for 2 seconds

        keyAnimator.SetTrigger("Close"); // Stop the animation by resetting the trigger/bool
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHasKey) return;
        if (!hasRun && parent != null)
        {
            GetChild();
            hasRun = true;
        }

        // Debug.Log(selectedEnemy);

        if (selectedEnemy == null)
        {
            Debug.Log("Player now has the key");
            playerHasKey = true;
            StartCoroutine(StartAndStopAnimator());
        }
    }
}
