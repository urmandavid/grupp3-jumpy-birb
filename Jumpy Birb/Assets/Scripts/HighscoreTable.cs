using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HighscoreTable : MonoBehaviour
{
    public GameObject scoreTemplate;
    public Transform container;

    public List<HighscoreEntry> highScoreList;
    public List<TextMeshProUGUI> scoreTexts;
    public List<TextMeshProUGUI> names;
    public List<TextMeshProUGUI> posTexts;

    // Represents a single Highscore entry
    public void Start()
    {
        OnLevelWasLoaded(1);
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscore = JsonUtility.FromJson<Highscores>(jsonString);
        if (highscore != null)
        {
            foreach (HighscoreEntry high in highscore.highscores)
            {
                scoreAdd(high.score, high.name);
            }
        }
    }

    public class Highscores
    {
        public List<HighscoreEntry> highscores;
    }

    [System.Serializable]
    public class HighscoreEntry : IComparable<HighscoreEntry>
    {
        public int score;
        public string name;

        public int CompareTo(HighscoreEntry other)
        {
            // Alphabetic sort if points are equal. [A to Z]
            if (this.score == other.score)
            {
                return this.name.CompareTo(other.name);
            }
            // Default to points sort. [High to low]
            return other.score.CompareTo(this.score);
        }
    }
    public void addHighScore(int score, string name)
    {
        HighscoreEntry highscore = new HighscoreEntry { score = score, name = name };

        highScoreList.Add(highscore);
        highScoreList.Sort();

        UIHighScore(highscore);
    }

    public void UIHighScore(HighscoreEntry entry)
    {
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscore = new Highscores { highscores = highScoreList };

        createPrefab();

        string json = JsonUtility.ToJson(highscore);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    public void createPrefab()
    {
        if (container == null)
        {
            return;
        }

        GameObject ST = Instantiate(scoreTemplate);
        ST.transform.SetParent(container.transform);

        posTexts.Add(ST.transform.Find("posText").GetComponent<TextMeshProUGUI>());
        scoreTexts.Add(ST.transform.Find("scoreText").GetComponent<TextMeshProUGUI>());
        names.Add(ST.transform.Find("nameText").GetComponent<TextMeshProUGUI>());

        for (int i = 0; i < posTexts.Count; i++)
        {
            posTexts[i].SetText((i + 1).ToString());
            scoreTexts[i].SetText(highScoreList[i].score.ToString());
            names[i].SetText(highScoreList[i].name);
        }
    }

    public void scoreAdd(int score, String name)
    {
        addHighScore(score, name);
    }

    public void OnLevelWasLoaded(int level)
    {
        /*

        highScoreList.Clear();
        scoreTexts.Clear();
        names.Clear();
        posTexts.Clear();

        */
    }

}