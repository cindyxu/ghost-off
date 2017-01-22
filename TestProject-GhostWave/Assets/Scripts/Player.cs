using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.GetComponent<Ghost> () != null) {
			Camera.main.GetComponent<CameraShake> ().Shake (5, 3);
		}
	}
}
