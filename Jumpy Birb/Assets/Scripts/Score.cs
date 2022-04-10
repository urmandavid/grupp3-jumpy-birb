using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreOnDeath;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI spaceToPlay;
    public static float score;
    private int highestScore;

    public bool startedJumping;
    private HighscoreTable ht;
    // Start is called before the first frame update
    private void Start()
    {
        ht = FindObjectOfType<HighscoreTable>();
        print(ht.name);
        getHighscore();
    }

    // Update is called once per frame
    void Update()
    {
        if (startedJumping)
        {
            score += Time.deltaTime * 25;
            scoreOnDeath.SetText(((int)score).ToString());
            scoreText.SetText(((int)score).ToString());
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
            highestScore = (int)score;
            highScoreText.SetText("Highscore : " + ((int)score).ToString());
        }
    }
    public void getHighscore()
    {
        if(ht.highScoreList.Count > 0)
        {
            highestScore = ht.highScoreList[0].score;
            highScoreText.SetText("Highscore : " + highestScore.ToString());
        }
        else
        {
            highScoreText.SetText("Highscore : 0");
        }
    }
}
