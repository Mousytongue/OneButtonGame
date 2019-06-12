using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarFillScript : MonoBehaviour {

	public float mMaxBar = 255;
	public float mMinBar = 10;
	public float mMaxTime = 2;
	public GameObject mPlayer;

	private bool isGrounded;
	private float mTimer;
	private RectTransform mBarRect;
	private float mBarSize;
	private float mFillSpeed;
	private Rigidbody mPlayerRb;
	private PlayerScript mPS;
	private bool mSpaceDown;

	// Use this for initialization
	void Start () {
		mTimer = 0;
		mFillSpeed = (mMaxBar - mMinBar) / mMaxTime; 
		mSpaceDown = false;
		mBarRect = transform as RectTransform;
		mBarSize = mBarRect.rect.width;
		mPlayerRb = mPlayer.GetComponent<Rigidbody> ();
		mPS = mPlayer.GetComponent<PlayerScript> ();
	}

	// Update is called once per frame
	void Update () {
		isGrounded = mPS.IsGrounded ();

		//Check Space Down/Up
		if (Input.GetKeyDown ("space")) {
			mSpaceDown = true;
		}
		if (Input.GetKeyUp ("space")) {
			mSpaceDown = false;
			JumpPlayer ();
			mTimer = 0;
		}

		//If Bar isnt filled an space is down, increment
		if (mSpaceDown == true && mBarSize <= mMaxBar && isGrounded)
			mTimer += Time.deltaTime;
		UpdateBar ();
	}

	void UpdateBar(){
		//Change Width of bar
		mBarSize = mMinBar + (mTimer * mFillSpeed);
		if (mBarSize >= mMaxBar)
			mBarSize = mMaxBar;

		mBarRect.sizeDelta = new Vector2 (mBarSize, mBarRect.sizeDelta.y);

		//Change Color of bar
		GetComponent<Image>().color = new Color32(255, (byte)(256 - mBarSize), (byte)(256 - mBarSize), 255);
	}

	void JumpPlayer(){
		mPlayerRb.AddForce (mBarSize, mBarSize * 3, 0, 0);
	}

}

