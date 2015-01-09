using UnityEngine;
using System.Collections;

public class playerDie : MonoBehaviour {

    public static bool gamePaused = false;
	private float time;
    public GameObject player;

    void OnTriggerEnter (Collider playerSphereCollider){
        Destroy(playerSphereCollider);
        time = timeTracker.timer;
        PauseGame();
        SubmitHighscores();
    }
    
    public static void PauseGame()
    {
        // Pause game
        Time.timeScale = 0;
        gamePaused = true;
        
        // Instantiate menu scene
        Application.LoadLevel ("SettingsScene");

        timeTracker.timer = 0.0f;

    }
    
	public void SubmitHighscores()
	{
		
	}
}
