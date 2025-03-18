using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject ghostPageParent;
    public GameObject ghostPage;
    public GameObject directionsPage;
    public string gameScene;

    public GameObject[] ghostPages;
    private int currentIndex = 0;

    public void Play()
    {
        if (!string.IsNullOrEmpty(gameScene))
        {
            SceneManager.LoadScene(gameScene);
        }
        else
        {
            Debug.LogError("Scene did not get set");
        }
    }

    public void ShowDirections()
    {
        if (directionsPage != null)
        {
            directionsPage.SetActive(true);
        }
    }

    public void ShowGhostPage()
    {
        if (ghostPageParent != null)
        {
            ghostPageParent.SetActive(true);
        }

        if (ghostPages.Length > 0)
        {
            currentIndex = 0;
            UpdateGhostPages();
        }
    }

    public void CloseDirections()
    {
        if (directionsPage != null)
        {
            directionsPage.SetActive(false);
        }
    }

    public void CloseGhost()
    {
        if (ghostPages.Length > 0)
        {
            foreach (GameObject page in ghostPages)
            {
                page.SetActive(false);
            }
        }
    }

    public void NextGhostPage()
    {
        if (currentIndex < ghostPages.Length - 1)
        {
            currentIndex++;
            UpdateGhostPages();
        }
    }

    public void PreviousGhostPage()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            UpdateGhostPages();
        }
    }

    private void UpdateGhostPages()
    {
        for (int i = 0; i < ghostPages.Length; i++)
        {
            ghostPages[i].SetActive(i == currentIndex);
        }
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
