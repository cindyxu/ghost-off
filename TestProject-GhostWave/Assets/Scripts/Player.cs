using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public AudioClip dieClip;

	private WaveEmitter mEmitter;

	void Start () {
		mEmitter = GetComponent<WaveEmitter> ();
		Debug.Log (mEmitter);
	}

	void OnTriggerEnter (Collider other) {
		if (other.GetComponent<Ghost> () != null) {
			die ();
		}
	}

	private void die () {
		mEmitter.enabled = false;
		transform.parent.GetComponent<AudioSource> ().PlayOneShot (dieClip);
		Game.GameOver ();
	}
}
