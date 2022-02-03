using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public float wallSpawnTime;
    public GameObject wall;
    public float height;

    // Start is called before the first frame update

    public void startSpawning()
    {
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
