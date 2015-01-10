using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Parse;
using System;
using System.IO;
using System.Threading.Tasks;

public class playerDie : MonoBehaviour {

    public static bool gamePaused = false;
	private float time;
    public float[] highScores = new float[]{};
    public float[] testScores = new float[]{1,2,3};

    void Start()
    {
        
    }

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
