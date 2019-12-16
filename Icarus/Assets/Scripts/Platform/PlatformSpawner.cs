using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject standardPlatformPrefab;
    public GameObject flamingPlatformPrefab;
    public GameObject fadingPlatformPrefab;
    public GameObject[] movingPlatformPrefab;


    public float min_X = -2f, max_X = 2f;
    public float platformSpawnTimer = 2f;

    private float currPlatformSpawnTimer;

    private uint platformSpawnCount;


    // Start is called before the first frame update
    void Start()
    {
        currPlatformSpawnTimer = platformSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatform();
    }

    void SpawnPlatform()
    {

        currPlatformSpawnTimer += Time.deltaTime;
        
        if (currPlatformSpawnTimer >= platformSpawnTimer)
        {
            platformSpawnCount++;

            Vector2 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);

            GameObject newPlatform = null;

            if (platformSpawnCount < 2)
            {
                newPlatform = Instantiate(standardPlatformPrefab, temp, Quaternion.identity);
            }
            else if(platformSpawnCount == 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(standardPlatformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(
                        movingPlatformPrefab[Random.Range(0, movingPlatformPrefab.Length)], //random between left or right
                        temp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(standardPlatformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(flamingPlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatform = Instantiate(standardPlatformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatform = Instantiate(fadingPlatformPrefab, temp, Quaternion.identity);
                }

                platformSpawnCount = 0; //reset spawner loop
            }
            if(newPlatform)
                newPlatform.transform.parent = transform; //avoid hierarchy clustering

            currPlatformSpawnTimer = 0f;

        } //spawn platforms
    }
}
