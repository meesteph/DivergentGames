using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class timeTracker : MonoBehaviour {

	public static float timer;
	
	// Update is called once per frame
	void Update () {
		Text gameTime = GetComponent<Text> ();
		timer = Time.fixedTime;
		gameTime.text = "Timer: " + timer.ToString();
	}
}
