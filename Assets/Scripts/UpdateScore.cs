using UnityEngine;
using TMPro;

public class UpdateScore : MonoBehaviour
{

    private Score score;
    [SerializeField] TMP_Text RetryScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Score score = GameObject.FindWithTag("HUD").GetComponentInChildren<Score>();
        Debug.Log(score.score);
        RetryScore.text = score.score.ToString();
        GameObject hud = GameObject.FindWithTag("HUD");
            if (hud != null) hud.SetActive(false);
        // ScoreController ScoreContainer = GameObject.FindWithTag("HUD").GetComponent<ScoreController>();
        // RetryScore.text = ScoreContainer._score.ToString();
    }

    // Update is called once per frame
}
