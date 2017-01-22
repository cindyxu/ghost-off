using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour {

	public float spawnDelayMs;
	public string[] ghostResNames;
	public int maxGhosts;

	private float mCurrDelayMs = 0;
	private Bounds mBounds;

	// Use this for initialization
	void Start () {
		mBounds = GetComponent<Collider> ().bounds;
	}
	
	// Update is called once per frame
	void Update () {
		mCurrDelayMs += Time.deltaTime * 1000;
		while (mCurrDelayMs > spawnDelayMs) {
			mCurrDelayMs -= spawnDelayMs;
			if (GameObject.FindObjectsOfType<Ghost> ().Length < maxGhosts) {
				spawnGhost ();
			}
		}
	}

	private void spawnGhost () {
		float rand = Random.value;
		float xRatio = mBounds.size.x / (mBounds.size.x + mBounds.size.z);
		float zRatio = mBounds.size.z / (mBounds.size.x + mBounds.size.z);

		float dx, dz;
		if (rand < 0.5f) {
			if (rand < xRatio / 2) {
				dx = -mBounds.extents.x + (rand / (xRatio / 2)) * mBounds.size.x;
				dz = mBounds.extents.z;
			} else {
				dz = -mBounds.extents.z + ((rand - xRatio) / (zRatio / 2)) * mBounds.size.z;
				dx = mBounds.extents.x;
			}
		} else {
			if (rand - 0.5f < xRatio / 2) {
				dx = -mBounds.extents.x + ((rand - 0.5f) / (xRatio / 2)) * mBounds.size.x;
				dz = -mBounds.extents.z;
			} else {
				dz = -mBounds.extents.z + ((rand - 0.5f - xRatio) / (zRatio / 2)) * mBounds.size.z;
				dx = -mBounds.extents.x;
			}
		}

		Vector3 spawnPt = new Vector3 (mBounds.center.x + dx, mBounds.min.y, mBounds.center.z + dz);
		string ghostResName = ghostResNames [Random.Range (0, ghostResNames.Length)];
		GameObject.Instantiate (Resources.Load (ghostResName), spawnPt, Quaternion.identity);
	}

}
