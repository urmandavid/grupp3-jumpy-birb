using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveleft : MonoBehaviour
{
    private float speed;
    [Header("Speeds")]
    public float speedEasy;
    public float speedMedium;
    public float speedHard;
    // Update is called once per frame
    private void Start()
    {
        GameDifficulty GD = FindObjectOfType<GameDifficulty>();
        if (GD != null)
        {
            switch (GD.gameDiff)
            {
                case GameDifficulty.gameDifficulty.Easy:
                    speed = speedEasy;
                    break;
                case GameDifficulty.gameDifficulty.Medium:
                    speed = speedMedium;
                    break;
                case GameDifficulty.gameDifficulty.Hard:
                    speed = speedHard;
                    break;
            }
        }
        else
        {
            speed = speedMedium;
        }
    }
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
