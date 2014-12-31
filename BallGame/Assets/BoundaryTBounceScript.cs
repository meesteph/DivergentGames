using UnityEngine;
using System.Collections;

public class BoundaryTBounceScript : MonoBehaviour {

	void OnTriggerEnter(Collider playerSphere)
	{
		playerSphere.rigidbody.velocity = new Vector3 
			(playerSphere.rigidbody.velocity.x,
			 -playerSphere.rigidbody.velocity.y,
			 0.0f);
	}
}
