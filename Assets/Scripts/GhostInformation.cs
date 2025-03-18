using UnityEngine;
using UnityEngine.UI;

public class GhostInfoManager : MonoBehaviour
{
    public Text headerText;
    public Text bodyText;
    public Image ghostImage;
    public Button nextButton;
    public Button prevButton;

    public Sprite[] ghostSprites; 
    public string[] ghostNames;
    public string[] ghostDescriptions;

    private int currentGhostIndex = 0;

    private void Start()
    {
        UpdateGhostPage();
        CheckButtonStates();
    }

    public void NextGhost()
    {
        if (currentGhostIndex < ghostNames.Length - 1)
        {
            currentGhostIndex++;
            UpdateGhostPage();
        }
        CheckButtonStates();
    }

    public void PreviousGhost()
    {
        if (currentGhostIndex > 0)
        {
            currentGhostIndex--;
            UpdateGhostPage();
        }
        CheckButtonStates();
    }

    private void UpdateGhostPage()
    {
        headerText.text = ghostNames[currentGhostIndex];
        bodyText.text = ghostDescriptions[currentGhostIndex];
        ghostImage.sprite = ghostSprites[currentGhostIndex];
    }

    private void CheckButtonStates()
    {
        prevButton.interactable = currentGhostIndex > 0;
        nextButton.interactable = currentGhostIndex < ghostNames.Length - 1;
    }

    public void CloseGhostPage()
    {
        gameObject.SetActive(false);
    }
}
