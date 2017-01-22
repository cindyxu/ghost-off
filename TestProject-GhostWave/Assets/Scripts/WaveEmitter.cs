using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEmitter : MonoBehaviour {

	public float minDelayMs;
	public float emitForce;
	public float emitTorque;

	public string attk1WaveResName;
	public string attk2WaveResName;
	public string attk3WaveResName;

	private AudioSource mAudioSource;

	private float mLastEmission = Mathf.NegativeInfinity;

	// Use this for initialization
	void Start () {
		mAudioSource = GetComponentInParent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (mLastEmission + minDelayMs < Time.time * 1000) {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				emitWave (1);
			} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
				emitWave (2);
			} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
				emitWave (3);
			}
		}
	}

	private void emitWave (int waveIdx) {

		string waveResName;

		if (waveIdx == 1) {
			waveResName = "Wave1";
		}
		else if (waveIdx == 2) {
			waveResName = "Wave2";
		}
		else {
			waveResName = "Wave3";
		}

		GameObject wave = GameObject.Instantiate (
			Resources.Load (waveResName),
			transform.position,
			Quaternion.LookRotation(transform.forward))
			as GameObject;
		wave.GetComponent<Rigidbody> ().AddForce (transform.forward * emitForce, ForceMode.Impulse);
		wave.GetComponent<Rigidbody> ().AddTorque (transform.forward * emitTorque);

		mLastEmission = Time.time * 1000;
	}
}
