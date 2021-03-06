﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Game {
	
	public enum State {
		TITLE,
		PLAYING,
		GAME_OVER,
		HOW_TO_PLAY,
		CREDITS
	}

	public static int pointAccum = 100;

	private static int sPoints = 0;
	private static State sState;

	public static void Title () {
		if (sState != State.TITLE) {
			sState = State.TITLE;
			enterTitleScene ();
		}
	}

	private static void enterTitleScene () {
		SceneManager.LoadScene ("Title");
	}

	public static void Play () {
		if (sState != State.PLAYING) {
			sState = State.PLAYING;
			sPoints = 0;
			enterPlayScene ();
		}
	}

	private static void enterPlayScene () {
		SceneManager.LoadScene ("Play");
	}

	public static void GhostOff () {
		if (sState == State.PLAYING) {
			sPoints += pointAccum;
		}
	}

	public static void GameOver () {
		if (sState != State.GAME_OVER) {
			sState = State.GAME_OVER;
			enterGameOverScene ();
		}
	}

	private static void enterGameOverScene () {
		SceneManager.LoadScene ("GameOver");
	}

	public static void HowToPlay () {
		if (sState != State.HOW_TO_PLAY) {
			sState = State.HOW_TO_PLAY;
			enterHowToPlayScene ();
		}
	}

	private static void enterHowToPlayScene () {
		SceneManager.LoadScene ("HowToPlay");
	}

	public static void Credits () {
		if (sState != State.CREDITS) {
			sState = State.CREDITS;
			enterCreditsScene ();
		}
	}

	private static void enterCreditsScene () {
		SceneManager.LoadScene ("Credits");
	}

}
