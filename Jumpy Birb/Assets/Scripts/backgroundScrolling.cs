using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{

    //Speed aplied to all backgrounds
    public float easySpeed;
    public float mediumSpeed;
    public float hardSpeed;
    private float baseScrollSpeed;

    //The Background Objects
    public GameObject[] backgrounds;
    public float[] scrollSpeed;

    private float time;

    private Movement player;
    private Score score;

    private void Start()
    {
        player = FindObjectOfType<Movement>();
        score = FindObjectOfType<Score>();
        switch (GameDifficulty.gameDiff)
        {
            case GameDifficulty.gameDifficulty.Easy:
                baseScrollSpeed = easySpeed;
                break;
            case GameDifficulty.gameDifficulty.Medium:
                baseScrollSpeed = mediumSpeed;
                break;
            case GameDifficulty.gameDifficulty.Hard:
                baseScrollSpeed = hardSpeed;
                break;
        }
    }
    void FixedUpdate()
    {
        if (!player.died && score.startedJumping)
        {
            for (int i = 0; i < backgrounds.Length; i++)
            {
                time += Time.deltaTime / 4;
                Renderer rend = backgrounds[i].GetComponent<Renderer>();
                float offset = time * (scrollSpeed[i] + baseScrollSpeed);

                rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
            }
        }
        else
        {
            time = 0;
        }
    }
}
