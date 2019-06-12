using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[Header("Player Dropping off Map")]
	public float mMinY = -25;
	public GameObject mPlayer;
    [Header("Scene to Load")]
    public string sceneToLoad;

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		float mY = mPlayer.transform.position.y;
        if (mY <= mMinY)
            if (sceneToLoad.Length != 0)
            {
                SceneManager.LoadScene(sceneToLoad);
            } else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
			
	}
}
