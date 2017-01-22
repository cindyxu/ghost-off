using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {
	
	public TitleSelection startSelection;
	public TitleSelection howToPlaySelection;
	public TitleSelection creditsSelection;

	private TitleSelection mCurrSelection; 

	void Update () {
		Vector3 screenPos = Input.mousePosition;

		if (RectTransformUtility.RectangleContainsScreenPoint (
			startSelection.GetComponent<RectTransform> (), screenPos)) {
			setSelection (startSelection);
		} else if (RectTransformUtility.RectangleContainsScreenPoint (
			howToPlaySelection.GetComponent<RectTransform> (), screenPos)) {
			setSelection (howToPlaySelection);
		} else if (RectTransformUtility.RectangleContainsScreenPoint (
			creditsSelection.GetComponent<RectTransform> (), screenPos)) {
			setSelection (creditsSelection);
		} else setSelection (null);

		if (Input.GetMouseButtonUp (0)) {
			select ();
		}
	}

	private void setSelection (TitleSelection selection) {

		startSelection.setSelected (false);
		howToPlaySelection.setSelected (false);
		creditsSelection.setSelected (false);

		if (selection != null) {
			selection.setSelected (true);
		}

		mCurrSelection = selection;
	}

	private void select () {
		if (mCurrSelection != null) {
			if (mCurrSelection == startSelection) {
				Game.Play ();
			} else if (mCurrSelection == howToPlaySelection) {
			} else if (mCurrSelection == creditsSelection) {
			}
		}
	}

}
