using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SoundToggleManager : MonoBehaviour {
	
	Toggle soundToggle;
    public static Text[] highscoreText;
    public static List<float> highScores = new List<float>{};
    private float time;
	
    void Awake()
    {
		updateSoundSettings ();

        highscoreText = GameObject.Find("SettingsPanel").GetComponentsInChildren<Text>();

        if(!PlayerPrefs.HasKey("highA"))
        {
            Debug.Log("New player");
            PlayerPrefs.SetFloat("highA", 0.0f);
            PlayerPrefs.SetFloat("highB", 0.0f);
            PlayerPrefs.SetFloat("highC", 0.0f);
            PlayerPrefs.SetFloat("timer", 0.0f);
        }

        if(PlayerPrefs.GetFloat("timer") > 0)
        {
            Debug.Log(PlayerPrefs.GetFloat("timer"));
        }

        highScores.Add(PlayerPrefs.GetFloat("highA"));
        highScores.Add(PlayerPrefs.GetFloat("highB"));
        highScores.Add(PlayerPrefs.GetFloat("highC"));
        highScores.Add(PlayerPrefs.GetFloat("timer"));
        highScores.Sort();

        PlayerPrefs.SetFloat("highA", highScores[highScores.Count-1]);
        PlayerPrefs.SetFloat("highB", highScores[highScores.Count-2]);
        PlayerPrefs.SetFloat("highC", highScores[highScores.Count-3]);

        highScores = new List<float>{};

        SoundToggleManager.highscoreText[5].text = "First: " + PlayerPrefs.GetFloat("highA") + " seconds";
        SoundToggleManager.highscoreText[6].text = "Second: " + PlayerPrefs.GetFloat("highB") + " seconds";
        SoundToggleManager.highscoreText[7].text = "Third: " + PlayerPrefs.GetFloat("highC") + " seconds";

        timeTracker.timer = 0.0f;
        PlayerPrefs.SetFloat("timer", 0.0f);
    }
	public void updateSoundSettings()
	{
		soundToggle = GameObject.Find("SettingsPanel").GetComponentInChildren<Toggle>();
		if(soundToggle.isOn) {
			Debug.Log ("Toggled on");
			AudioListener.volume = 1;
		} else {
			Debug.Log ("Toggled off");
			AudioListener.volume = 0;
		}
	}
	
}
