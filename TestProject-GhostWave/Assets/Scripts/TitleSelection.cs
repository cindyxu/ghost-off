using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleSelection : MonoBehaviour {

	public Sprite neutralSprite;
	public Sprite highlightSprite;
	private Image mImage;

	void Start () {
		mImage = GetComponent<Image> ();
	}

	public void setSelected (bool highlight) {
		if (highlight) {
			mImage.overrideSprite = highlightSprite;
		} else {
			mImage.overrideSprite = neutralSprite;
		}
	}
}
