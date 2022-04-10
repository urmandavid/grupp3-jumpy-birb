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
    }

    private void SetDifficultyText()
    {
        difficultyText.SetText("Current Difficulty : " + gameDiff);
    }
}
