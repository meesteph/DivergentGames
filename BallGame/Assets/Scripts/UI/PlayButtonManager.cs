using UnityEngine;
using System.Collections;

public class PlayButtonManager : MonoBehaviour {

	public void playGame()
	{
		Time.timeScale = 1;
		Application.LoadLevel ("MainScene");
	}

}
