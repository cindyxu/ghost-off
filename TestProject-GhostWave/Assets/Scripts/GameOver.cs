using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

	public float showTimeMs;
	private float mElapsedTimeMs = 0;

	// Update is called once per frame
	void Update () {
		mElapsedTimeMs += Time.deltaTime * 1000;
		if (mElapsedTimeMs > showTimeMs) {
			Game.Title ();
		}
	}
}
