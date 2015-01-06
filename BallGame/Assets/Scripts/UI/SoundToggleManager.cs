using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundToggleManager : MonoBehaviour {
	
	Toggle soundToggle;
	
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
