using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEmitter : MonoBehaviour {

	public float minDelayMs;
	public float emitForce;
	public float emitTorque;

	private AudioSource mAudioSource;
	private float mLastEmission = Mathf.NegativeInfinity;

	// Use this for initialization
	void Start () {
		mAudioSource = GetComponentInParent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if (mLastEmission + minDelayMs < Time.time * 1000) {
			if (Input.GetMouseButton(0))
				emitWave(1);

			else if (Input.GetMouseButton(1))
				emitWave(3);

			else if (Input.GetMouseButton(2))
				emitWave(2);
			
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
