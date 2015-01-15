using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

	public GameObject VisualEffect;

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter (Collider PlayerSphere){
		VisualEffect.transform.localScale = new Vector3 (Screen.height / 12.0f, Screen.height / 12.0f, Screen.height / 12.0f);
		Instantiate (VisualEffect, transform.position, transform.rotation);
		Time.timeScale = 0;
		Debug.Log (Time.timeScale);
		Destroy (gameObject);
	}

}
