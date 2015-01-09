using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class timeTracker : MonoBehaviour {

	public static float timer = 0.0f;
	public static float timeScale = 1;

	void Start(){

		Time.timeScale = 1.0f;
	}

	// Update is called once per frame
	void Update () {
		if (!playerDie.gamePaused) 
		{
			Text gameTime = GetComponent<Text> ();
			timer += Time.deltaTime / Time.timeScale;
			timer = Mathf.Round(timer * 1000f) / 1000f;
			gameTime.text = "Timer: " + timer.ToString ();
		}


	}	
}
