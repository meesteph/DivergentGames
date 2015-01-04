using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class timeTracker : MonoBehaviour {

	public static float timer = 0.0f;

	void Start(){

		Time.timeScale = 4.0f;
	}

	// Update is called once per frame
	void Update () {
		if (!playerDie.gamePaused) 
		{
			Text gameTime = GetComponent<Text> ();
			timer += Time.deltaTime / Time.timeScale;
			gameTime.text = "Timer: " + timer.ToString ();
		}
	}	
}
