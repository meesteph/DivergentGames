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

    void OnTriggerEnter (Collider playerSphereCollider){
		if (playerSphereCollider.tag == "Player"){
        	Destroy(playerSphereCollider);
        	HandleDeath();
		}
    }
    
    public static void HandleDeath()
    {
        PlayerPrefs.SetFloat("timer", timeTracker.timer);

        // Pause game
        Time.timeScale = 0;
        gamePaused = true;
        
        // Instantiate menu scene
        Application.LoadLevel ("SettingsScene");
    }
}
