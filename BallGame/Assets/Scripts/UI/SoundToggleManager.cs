using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Parse;

public class SoundToggleManager : MonoBehaviour {
	
	Toggle soundToggle;
    public static Text[] highscoreText;
    public static List<float> highScores = new List<float>{};
    private float time;
	
    void Awake()
    {
		if (PlayerPrefs.HasKey ("Sound Volume") == false){
			PlayerPrefs.SetFloat("Sound Volume", 1.0f);
		}

		soundToggle = GameObject.Find("SettingsPanel").GetComponentInChildren<Toggle>();

		AudioListener.volume = PlayerPrefs.GetFloat ("Sound Volume");

		if (PlayerPrefs.GetFloat ("Sound Volume") == 1.0f) {

			soundToggle.isOn = true;

		} else {
		
			soundToggle.isOn = false;
		
		}

		updateSoundSettings ();


        highscoreText = GameObject.Find("SettingsPanel").GetComponentsInChildren<Text>();

		string playerName = ParseUser.CurrentUser.Username;

        if(!PlayerPrefs.HasKey("highA"))
        {
            Debug.Log("New player");
            PlayerPrefs.SetFloat("highA" + playerName, 0.0f);
            PlayerPrefs.SetFloat("highB" + playerName, 0.0f);
			PlayerPrefs.SetFloat("highC" + playerName, 0.0f);
			PlayerPrefs.SetFloat("timer", 0.0f);
        }

        if(PlayerPrefs.GetFloat("timer") > 0)
        {
            Debug.Log(PlayerPrefs.GetFloat("timer"));
        }

		highScores.Add(PlayerPrefs.GetFloat("highA" + playerName));
		highScores.Add(PlayerPrefs.GetFloat("highB" + playerName));
		highScores.Add(PlayerPrefs.GetFloat("highC" + playerName));
        highScores.Add(PlayerPrefs.GetFloat("timer"));
        highScores.Sort();

		PlayerPrefs.SetFloat("highA" + playerName, highScores[highScores.Count-1]);
		PlayerPrefs.SetFloat("highB" + playerName, highScores[highScores.Count-2]);
		PlayerPrefs.SetFloat("highC" + playerName, highScores[highScores.Count-3]);

        highScores = new List<float>{};

		SoundToggleManager.highscoreText[5].text = "First: " + PlayerPrefs.GetFloat("highA" + playerName) + " seconds";
		SoundToggleManager.highscoreText[6].text = "Second: " + PlayerPrefs.GetFloat("highB" + playerName) + " seconds";
		SoundToggleManager.highscoreText[7].text = "Third: " + PlayerPrefs.GetFloat("highC" + playerName) + " seconds";

        timeTracker.timer = 0.0f;
        PlayerPrefs.SetFloat("timer", 0.0f);
    }
	public void updateSoundSettings()
	{
		soundToggle = GameObject.Find("SettingsPanel").GetComponentInChildren<Toggle>();
		if(soundToggle.isOn) {
			PlayerPrefs.SetFloat("Sound Volume", 1.0f);
			AudioListener.volume = 1.0f;
		} else {
			PlayerPrefs.SetFloat("Sound Volume", 0.0f);
			AudioListener.volume = 0.0f;
		}

	}
	
}
