using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundToggleManager : MonoBehaviour {
	
	Toggle soundToggle;
	public static bool soundOn = true;
	
	public void updateSoundSettings()
	{
		soundToggle = GameObject.Find("SettingsPanel").GetComponentInChildren<Toggle>();
		soundOn = false; // IsActive();
		if(soundToggle.isOn) {
			soundOn = true;
			Debug.Log ("Toggled on");
			AudioListener.volume = 1;
		} else {
			soundOn = false;
			Debug.Log ("Toggled off");
			AudioListener.volume = 0;
		}
	}
	
}
