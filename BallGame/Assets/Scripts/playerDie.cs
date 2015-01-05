using UnityEngine;
using System.Collections;

public class playerDie : MonoBehaviour {

	public static bool gamePaused = false;
    public GameObject player;
    private float time;

	void OnTriggerEnter (Collider playerSphereCollider){
		Destroy(playerSphereCollider);
		PauseGame();
		time = timeTracker.timer;
		SubmitHighscores();
		timeTracker.timer = 0.0f;
	}
	
	public void PauseGame()
	{
		// Pause game
		Time.timeScale = 0;
		gamePaused = true;
		
		// Instantiate menu scene
		Application.LoadLevel ("SettingsScene");
	}
	
	public void SubmitHighscores()
	{
		
	}
}
