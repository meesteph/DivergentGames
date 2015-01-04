using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundToggleManager : MonoBehaviour {
	
	Selectable soundToggle;
	public static bool soundOn = true;
	
	public void updateSoundSettings()
	{
		soundToggle = GameObject.Find("SettingsPanel").GetComponentInChildren<Selectable>();
		soundOn = false; // IsActive();
	}
	
}
