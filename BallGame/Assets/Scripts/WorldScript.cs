using UnityEngine;
using System.Collections;

public class WorldScript : MonoBehaviour {

	private Vector3 screenBoundary;

    //public GameObject bounceNode;
    public GameObject player;
	public GameObject topBound;
	public GameObject rightBound;
	public GameObject leftBound;
	public GameObject lowerBound;

    public static int playerLives;
    public int startLives;

	void Start () {

        // Instantiate playerLives
        playerLives = startLives;

        // Spawn player
        Instantiate(player,new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

        // Move boundaries based on screen size
		rightBound.transform.position = new Vector3 ((Screen.width + 100)/2+2, 0.0f, 0.0f);
		leftBound.transform.position = new Vector3 (-(Screen.width + 100)/2-2, 0.0f, 0.0f);
		topBound.transform.position = new Vector3 (0.0f, (Screen.height + 100)/2 + 100, 0.0f);
		lowerBound.transform.position = new Vector3 (0.0f, -(Screen.height + 100)/2-2, 0.0f);

        // Adjust camera size based on screen size
		Camera.main.orthographicSize = 0.5f * Screen.height;

	}

	// Update is called once per frame
	void Update () {

        // Spawn bounce nodes where mouse clicks occur
        //if (Input.GetButtonDown("Fire1")) {
        //    Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,10.0f));
        //    Instantiate(bounceNode,new Vector3(p.x,p.y, 0.0f),Quaternion.identity);
        // }

	}
}
