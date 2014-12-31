using UnityEngine;
using System.Collections;

public class BounceTriggerScript : MonoBehaviour {

	public float forceCoefficient;

    private int ticks = 0;

	void OnTriggerEnter (Collider playerSphere)
	{
		Vector3 force = playerSphere.transform.position - transform.position;
		force = force / force.magnitude;		
		force = force * forceCoefficient;
		playerSphere.rigidbody.AddForce (force);
		Destroy (gameObject);
	}

    void Update() {

        if(ticks < 3) {
            ticks += 1;
            return;
        }

        Destroy(gameObject);
    }
}
