using UnityEngine;
using System.Collections;

public class playerDie : MonoBehaviour {

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
		
		// Instantiate pause GUI (highscores, 
	}
}
