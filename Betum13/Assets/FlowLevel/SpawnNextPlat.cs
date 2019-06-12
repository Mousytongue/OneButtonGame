using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpawnNextPlat : MonoBehaviour {
    const int MIN_GAP = 1;
    const int MAX_GAP = 3;
    const float MAX_HEIGHT_GAP = 4f;
    const float LOSE_HEIGHT = -25f;
    const int MAX_PLAT_COUNT = 4;
    bool spawnedNext = false;
    static Queue<GameObject> plats = new Queue<GameObject>();

    private void Start()
    {
        plats.Enqueue(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If I haven't spawned the next plat
        if (!spawnedNext)
        {
            SpawnNext();
            spawnedNext = true;
        }
    }

    //Spawn a new platform that can be high, med, or low, and have a variable gap
    private void SpawnNext()
    {
        float distBetweenPlats, heightChange;

        //Platform must go up or stay level due to game end restriction height
        if (transform.position.y - MAX_HEIGHT_GAP < LOSE_HEIGHT)
            heightChange = (float)(MAX_HEIGHT_GAP * UnityEngine.Random.Range(0, 2)); //Max is exclusive
        else //Platform can go up or down
            heightChange = (float)(MAX_HEIGHT_GAP * UnityEngine.Random.Range(-1, 2));

        if (heightChange > 0) //Platform will be higher, so keep x gap at smallest, to make it easier
            distBetweenPlats = transform.localScale.x + (MIN_GAP + MAX_GAP) / 2f;
        else //Variable x gap
            distBetweenPlats = transform.localScale.x + (float)(UnityEngine.Random.Range(MIN_GAP, MAX_GAP + 1));

        //Create new platform
        Vector3 newLoc = new Vector3(transform.position.x + distBetweenPlats, transform.position.y + heightChange, transform.position.z);
        GameObject go = Instantiate(this.gameObject, newLoc, Quaternion.identity) as GameObject;

        //Enqueue new platform, dequeue old platform
        if (plats.Count > MAX_PLAT_COUNT)
            Destroy(plats.Dequeue());
        IncreaseScore();
    }

    private void IncreaseScore()
    {
        Text txtScore = GameObject.Find("Score").GetComponent<Text>();
        int score = Convert.ToInt32(txtScore.text) + 1;
        txtScore.text = score.ToString();
    }
}
