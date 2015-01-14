using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class timeTracker : MonoBehaviour {

	public static float timer;
	public static float timeScale = 1;
	public GameObject player;
	public int extraSpawnTime;
	private int extraSpawn = 1;

	void Start(){

		Time.timeScale = 1.0f;
	}

	// Update is called once per frame
	void Update () {

		// Increment timer and display
		if (!playerDie.gamePaused) 
		{
			Text gameTime = GetComponent<Text> ();
			timer += Time.deltaTime / Time.timeScale;
			timer = Mathf.Round(timer * 1000f) / 1000f;
			gameTime.text = "Timer: " + timer.ToString ();
		}

		// Spawn extra one extra every extraSpawnTime seconds
		if(timer >= extraSpawnTime * extraSpawn && extraSpawn < 5)
		{
			extraSpawn += 1;
			Instantiate(player,new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
		}
	}	
}
