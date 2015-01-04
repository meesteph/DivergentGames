using UnityEngine;
using System.Collections;

public class PlayButtonManager : MonoBehaviour {

	public void playGame()
	{
		Application.LoadLevel ("MainScene");
	}

}
