using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreTable : MonoBehaviour {

    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;

    private void Awake() {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate"); // NullReference

        entryTemplate.gameObject.SetActive(false);

        highscoreEntryList = new List<HighscoreEntry>() {
            new HighscoreEntry{ score = 9, name = "AAA" },
            new HighscoreEntry{ score = 8, name = "BBB" },
            new HighscoreEntry{ score = 7, name = "CCC" },
            new HighscoreEntry{ score = 6, name = "DDD" },
            new HighscoreEntry{ score = 5, name = "EEE" },
            new HighscoreEntry{ score = 4, name = "FFF" },
            new HighscoreEntry{ score = 3, name = "GGG" },
            new HighscoreEntry{ score = 2, name = "HHH" },
            new HighscoreEntry{ score = 1, name = "III" },
        };

        // >>> Fortsätt youtube tutorial på 9:00 minuter <<<
        // FEL >>> "NullReferenceException: Object reference not set to an instance of an object" (RAD 15)...

        // Entering custom Highscore for testing
        //AddHighscoreEntry(11, "DAV");

        //string jsonString = PlayerPrefs.GetString("highscoreTable");
        //Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);     >>> OBS: highscores.highscoreEntryList nedan! <<<

        // Sort entry list by Score
        for (int i = 0; i < highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscoreEntryList.Count; j++) {
                if (highscoreEntryList[j].score > highscoreEntryList[i].score) {
                    // Swap positions
                    HighscoreEntry tmp = highscoreEntryList[i];
                    highscoreEntryList[i] = highscoreEntryList[j];
                    highscoreEntryList[j] = tmp;
                }
            }
        }
        
        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 50f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<TextMeshProUGUI>().text = rankString;

        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<TextMeshProUGUI>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<TextMeshProUGUI>().text = name;

        transformList.Add(entryTransform);
    }

    // Represents a single Highscore entry
    [System.Serializable]
    private class HighscoreEntry {
        public int score;
        public string name;
    }

    /*
    private void AddHighscoreEntry(int score, string name) {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    
    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }
    
    void OnGUI() {
        //Delete all of the PlayerPrefs settings by pressing this Button
        if (GUI.Button(new Rect(100, 200, 200, 60), "Delete")) {
            PlayerPrefs.DeleteAll();
        }
    }
    */
}