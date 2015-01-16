using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

	public GameObject VisualEffect;
	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter (Collider PlayerSphere){
		if (PlayerSphere.tag == "Player")
		{
			VisualEffect.transform.localScale = new Vector3 (Screen.height / 12.0f, Screen.height / 12.0f, Screen.height / 12.0f);
			Instantiate (VisualEffect, transform.position, transform.rotation);

			audio.Play ();
			renderer.enabled = false;
			collider.enabled = false;

			Time.timeScale = 0.75f * Time.timeScale;

			StartCoroutine(WaitAndDestroy ());
		}
	}

	IEnumerator WaitAndDestroy(){
		yield return new WaitForSeconds(2.0f);
		Destroy (gameObject);
		Debug.Log("Destroyed");
	}
}
