using UnityEngine;
using System.Collections;

public class BoundaryRLBounceScript : MonoBehaviour {
	
	void OnTriggerEnter(Collider playerSphere)
	{
		audio.Play ();
		playerSphere.rigidbody.velocity = new Vector3 
			(-playerSphere.rigidbody.velocity.x,
			 playerSphere.rigidbody.velocity.y,
			 0.0f);
	}
}
