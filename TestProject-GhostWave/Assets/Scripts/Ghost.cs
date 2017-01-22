using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

	public string playerName;
	public float rotateSpeed;
	public float moveSpeed;

	private GameObject mPlayer;

	// Use this for initialization
	void Start () {
		mPlayer = GameObject.Find (playerName);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Slerp(transform.rotation,
			Quaternion.LookRotation(mPlayer.transform.position - transform.position),
			rotateSpeed * Time.deltaTime);

		//move towards the player
		transform.parent.position += transform.forward * moveSpeed * Time.deltaTime;
	}
}
