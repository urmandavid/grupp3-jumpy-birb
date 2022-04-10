using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDifficulty : MonoBehaviour
{
    public enum gameDifficulty { Easy, Medium, Hard }
    public static gameDifficulty gameDiff;

    public TextMeshProUGUI difficultyText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("gameDiff"))
        {
            gameDifficulty savedGameDiff = JsonUtility.FromJson<gameDifficulty>(PlayerPrefs.GetString("gameDiff"));
            gameDiff = savedGameDiff;
        }
        SetDifficultyText();
    }

    public void setDifficulty(string gameDiffText)
    {
        switch (gameDiffText)
        {
            case "Easy":
                gameDiff = gameDifficulty.Easy;
                break;
            case "Medium":
                gameDiff = gameDifficulty.Medium;
                break;
            case "Hard":
                gameDiff = gameDifficulty.Hard;
                break;
            default:
                gameDiff = gameDifficulty.Medium;
                break;
        }
        SetDifficultyText();
        SaveDifficulty();
    }

    private void SetDifficultyText()
    {
        difficultyText.SetText("Current Difficulty : " + gameDiff);
    }
    private void SaveDifficulty()
    {
        string json = JsonUtility.ToJson(gameDiff);
        PlayerPrefs.SetString("gameDiff", json);
    }
}
