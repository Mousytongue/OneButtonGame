using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {

	public GameObject mTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Transform mT = mTarget.transform;
		transform.position = new Vector3 (mT.position.x, mT.position.y + 1.5f, mT.position.z + -9.7f);
	}
}
