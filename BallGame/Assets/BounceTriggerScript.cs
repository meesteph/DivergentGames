using UnityEngine;
using System.Collections;

public class BounceTriggerScript : MonoBehaviour {

	public float forceCoefficient;

	void OnTriggerEnter (Collider playerSphere)
	{
		Vector3 force = playerSphere.transform.position - transform.position;
		force = force / force.magnitude;		
		force = force * forceCoefficient;
		playerSphere.rigidbody.AddForce (force);
		Destroy (gameObject);
	}
}
