using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public int playerLives;

	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = new Vector3 (Screen.height / 10,Screen.height / 10,Screen.height / 10);
		playerLives = 5;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
