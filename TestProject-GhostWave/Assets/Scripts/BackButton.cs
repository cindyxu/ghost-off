using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour {

	private RectTransform mRectTransform;

	// Use this for initialization
	void Start () {
		mRectTransform = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 screenPos = Input.mousePosition;
		if (Input.GetMouseButtonUp (0) && 
			RectTransformUtility.RectangleContainsScreenPoint (mRectTransform, screenPos)) {
			Game.Title ();
		}
	}
}
