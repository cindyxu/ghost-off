using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
	
	void OnTriggerEnter (Collider other) {
		Destroy (transform.gameObject);
		if (other.GetComponentInParent<Ghost> () != null) {
			Destroy (other.transform.parent.gameObject);
		}
	}

}