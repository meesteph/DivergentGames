using UnityEngine;
using System.Collections;

public class WorldScript : MonoBehaviour {

	private Vector3 screenBoundary;
	public GameObject topBound;
	public GameObject rightBound;
	public GameObject leftBound;
	public GameObject lowerBound;

	void Start () {
		rightBound.transform.position = new Vector3 ((Screen.width + 5)/2+2, 0.0f, 0.0f);
		leftBound.transform.position = new Vector3 (-(Screen.width + 5)/2-2, 0.0f, 0.0f);
		topBound.transform.position = new Vector3 (0.0f, (Screen.height + 5)/2 + 100, 0.0f);
		lowerBound.transform.position = new Vector3 (0.0f, -(Screen.height + 5)/2-2, 0.0f);

		Camera.main.orthographicSize = 0.5f * Screen.height;

	}
	// Update is called once per frame
	void Update () {
	


	}
}
