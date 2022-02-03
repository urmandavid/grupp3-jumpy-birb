using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI spaceToPlay;
    private float score;
    private float highestScore;

    public bool startedJumping;
    // Start is called before the first frame update
    void Start()
    {
        getHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        if (startedJumping)
        {
            score += Time.deltaTime * 25;
            scoreText.SetText(Mathf.Round(score).ToString());
            SetHighscore();
        }
    }
    public void SetSpaceToPlayTextInactive()
    {
        spaceToPlay.enabled = false;
    }
    public void SetHighscore()
    {
        if (highestScore <= score)
        {
            highestScore = score;
            highScoreText.SetText("Highscore : " + Mathf.Round(score).ToString());
            PlayerPrefs.SetFloat("Highscore", score);
        }
    }
    public void getHighscore()
    {
        highestScore = PlayerPrefs.GetFloat("Highscore");
        highScoreText.SetText("Highscore : " + Mathf.Round(highestScore).ToString());
    }
}
