using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed = 100f;

	// Use this for initialization
	void Start () {
		gameObject.transform.localScale = new Vector3 (Screen.height / 10,Screen.height / 10,Screen.height / 10);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}
}
