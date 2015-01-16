using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimescaleTrackerScript : MonoBehaviour {

	void Update()
	{ 
		Text timeScaleTracker = GetComponent<Text> ();

		if (!playerDie.gamePaused)
		{
			Time.timeScale += (Time.deltaTime / Time.timeScale) * 0.01f;
			timeScaleTracker.text = "Timescale: " + Time.timeScale.ToString();
		}
	}
}
