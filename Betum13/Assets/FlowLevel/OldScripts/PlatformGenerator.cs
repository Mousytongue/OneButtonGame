using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform player;
    public GameObject upperGround;
    public GameObject middleGround;
    public GameObject lowerGround;

    Vector3 location;
    const int START_INDEX = 8;
    const int ITERATION_SIZE = 6;
    const int ITERATIONS = 100;
    const int COUNT_TO_NEXT_ITERATION = 4;

    const float TOP_OFFSET = 0f;
    const float MID_OFFSET = -4f;
    const float BOTTOM_OFFSET = -10f;
    const float Y_RAND = .5f;
    const float X_RAND = .5f;

    // Use this for initialization
    void Start()
    {
        //Get the location that we will start spawning at
        location = new Vector3(player.position.x, (player.localPosition.y - player.localScale.y / 2) - .5f, player.localPosition.z);

        //Spawn a platform under the player
        Instantiate(upperGround, location, Quaternion.identity);

        //Spawn a platform just to the right of the player on bottom
        Instantiate(middleGround, new Vector3(location.x + upperGround.transform.localScale.x, location.y + MID_OFFSET, location.z), Quaternion.identity);

        //Spawn a platform to left of mid plat 
        Instantiate(upperGround, new Vector3(location.x - middleGround.transform.localScale.x, location.y + BOTTOM_OFFSET, location.z), Quaternion.identity);

        SpawnPlats(0, 0, upperGround);
        SpawnPlats(location.x + upperGround.transform.localScale.x, MID_OFFSET, middleGround);
        SpawnPlats(location.x - middleGround.transform.localScale.x, BOTTOM_OFFSET, lowerGround);
    }

    void SpawnPlats(float startXPos, float yOffset, GameObject ground)
    {
        float prevXPos = startXPos;
        //Instantiate a platform at randomly in chuncks of 3
        for (int i = START_INDEX; i <= ITERATION_SIZE * ITERATIONS; i += ITERATION_SIZE)
        {
            float newXPos = Random.Range(i, i + COUNT_TO_NEXT_ITERATION) + Random.Range(-X_RAND, X_RAND);

            //Check for overlap and move so no overlap
            if (newXPos - prevXPos <= ground.transform.localScale.x)
                newXPos += ground.transform.localScale.x + .5f;

            Vector3 spawnPos = new Vector3(newXPos, location.y + yOffset + Random.Range(-Y_RAND, Y_RAND), location.z);
            Instantiate(ground, spawnPos, Quaternion.identity);
            prevXPos = spawnPos.x;
        }
    }
}
