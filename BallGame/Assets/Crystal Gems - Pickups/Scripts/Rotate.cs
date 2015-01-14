using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	public float speed = 32f;
	public bool isEnabled = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isEnabled)
			transform.Rotate (Vector3.down * Time.deltaTime * speed);
	}

	public void SetRotation (bool opt)
	{
		isEnabled = opt;
	}
}
