using UnityEngine;
using System.Collections;
using Parse;

public class WorldScript : MonoBehaviour {

    //public GameObject bounceNode;
    public GameObject player;
	public GameObject topBound;
	public GameObject rightBound;
	public GameObject leftBound;
	public GameObject lowerBound;

    public static int playerLives;
    public int startLives;
    //private DeviceOrientation pastOrientation;
    private Vector3 screenBoundary;
    public static float verticalOffset;

	void Start () {
        
        // Instantiate playerLives & verticalOffset
        playerLives = startLives;
        verticalOffset = Screen.height*1.05f;
        // Spawn player
        Instantiate(player,new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

        moveBounds();

	}

	// Update is called once per frame
	void Update () {

        // Are we logged in?
       if (ParseUser.CurrentUser != null)
        {
            // do stuff with the user
        }
        else
        {
            Application.LoadLevel ("LoginScene");
        }

        // // Do this if the phone's orientation has changed since last frame
        // if(pastOrientation != Input.deviceOrientation)
        // {
        //     Time.timeScale = 0; // Pause timer until re-orientation completes
        //     moveBounds();
        // }

	}

    public void moveBounds()
    {
        // Move boundaries based on screen size
		rightBound.transform.position = new Vector3 ((Screen.width + 100)/2+2, 0.0f, 0.0f);
		rightBound.transform.localScale = new Vector3 (100.0f,100000.0f,100000.0f);
		
		leftBound.transform.position = new Vector3 (-(Screen.width + 100)/2-2, 0.0f, 0.0f);
		leftBound.transform.localScale = new Vector3 (100.0f,100000.0f,100000.0f);
		
		topBound.transform.position = new Vector3 (0.0f, (Screen.height + 100)/2 + verticalOffset, 0.0f);
		topBound.transform.localScale = new Vector3 (100000.0f,100.0f,100000.0f);
		
		lowerBound.transform.position = new Vector3 (0.0f, -(Screen.height + 100)/2-2, 0.0f);
		lowerBound.transform.localScale = new Vector3 (100000.0f, 5.0f, 100000.0f);


        // Adjust camera size based on screen size
        Camera.main.orthographicSize = 0.5f * Screen.height;

        // Get initial phone orientation
        //pastOrientation = Input.deviceOrientation;
        //Time.timeScale = timeTracker.timeScale; // Set the timescale back to what it was before phone rotation
    }
}
