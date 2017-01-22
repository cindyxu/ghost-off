using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

	public float lifetimeMs = 5000;

	private float mCurrDeltaTime = 0;

	void Update () {
		mCurrDeltaTime += Time.deltaTime * 1000;
		if (mCurrDeltaTime > lifetimeMs) {
			Destroy (transform.gameObject);
		}
	}
	
	void OnTriggerEnter (Collider other) {
		Destroy (transform.gameObject);
		if (other.GetComponentInParent<Ghost> () != null) {
			Destroy (other.transform.parent.gameObject);
		}
	}

}