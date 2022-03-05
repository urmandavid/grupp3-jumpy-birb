using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    private float wallSpawnTime;
    [Header("Spwan Times")]
    public float wallSpawnTimeEasy;
    public float wallSpawnTimeMedium;
    public float wallSpawnTimeHard;

    public GameObject wall;
    public float height;

    // Start is called before the first frame update

    public void startSpawning()
    {
        GameDifficulty GD = FindObjectOfType<GameDifficulty>();
        if(GD != null)
        {
            switch(GD.gameDiff)
            {
                case GameDifficulty.gameDifficulty.Easy:
                    wallSpawnTime = wallSpawnTimeEasy;
                   break;
                case GameDifficulty.gameDifficulty.Medium:
                    wallSpawnTime = wallSpawnTimeMedium;
                    break;
                case GameDifficulty.gameDifficulty.Hard:
                    wallSpawnTime = wallSpawnTimeHard;
                    break;
            }
        }
        else
        {
            wallSpawnTime = wallSpawnTimeMedium;
        }

        StartCoroutine(spawnWall());
    }

    public IEnumerator spawnWall()
    {
        while(true)
        {
            yield return null;
            // Spawna in vägg
            GameObject spawnedWall = Instantiate(wall, transform);
            spawnedWall.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);
            Destroy(spawnedWall, 5);
            yield return new WaitForSeconds(wallSpawnTime);
            // Vänta tills nästa väg
        }
    }
}
