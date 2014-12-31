using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class textScript : MonoBehaviour {

    Text livesText;

	// Use this for initialization
	void Start () {

        // Get Text element from Text component
        livesText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

        livesText.text = "Lives: " + WorldScript.playerLives.ToString();
	
	}
}
