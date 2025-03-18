using UnityEngine;
using UnityEngine.UIElements;
using TMPro;    // IMPORT This to use text

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLabel;   // Insert text UI element into here (via inspector) to display values using that UI text
    [SerializeField] TMP_Text scoreResult;
    public int score; // Score variable




    private void OnEnable() // Method for adding and removing listener
    {Messenger<int>.AddListener(GameEvent.INCREASE_SCORE, increaseScore);}
    private void OnDisable()
    {Messenger<int>.RemoveListener(GameEvent.INCREASE_SCORE, increaseScore);}


    public void Open()
    {
        gameObject.SetActive(true);
        score = 0;
        scoreLabel.text = score.ToString();    // Set score to 0 upon start
        
    }
    public void Close()
    {
        scoreResult.text = score.ToString();
        gameObject.SetActive(false);
    }
    
    private void increaseScore(int addedScore)
    {
        score += addedScore;
        scoreLabel.text = score.ToString();
    }


}
