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

    private Movement player;
    // Update is called once per frame
    private void Start()
    {
        player = FindObjectOfType<Movement>();
        switch (GameDifficulty.gameDiff)
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
    void Update()
    {
        if (!player.died)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }
}
