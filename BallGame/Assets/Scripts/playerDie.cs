using UnityEngine;
using System.Collections;

public class playerDie : MonoBehaviour {

	public static bool gamePaused = false;
	private int lives;
    public GameObject player;

	void OnTriggerEnter (Collider playerSphereCollider){
		Destroy(playerSphereCollider);
		PauseGame();
	}
	
	public void PauseGame()
	{
		// Pause game
		Time.timeScale = 0;
		gamePaused = true;
		
		// Instantiate menu scene
		Application.LoadLevel ("SettingsScene");
	}
}
