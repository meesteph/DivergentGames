using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimescaleTrackerScript : MonoBehaviour {

	void Update()
	{ 
		Text timeScaleTracker = GetComponent<Text> ();

		if (!playerDie.gamePaused)
		{
			Time.timeScale = 1.0f + (timeTracker.timer + 1.0f) / 100f;
			timeScaleTracker.text = "Timescale: " + Time.timeScale.ToString();
		}
	}
}
