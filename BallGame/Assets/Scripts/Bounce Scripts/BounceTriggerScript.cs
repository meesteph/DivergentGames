using UnityEngine;
using System.Collections;

public class BounceTriggerScript : MonoBehaviour {

	public float forceCoefficient;

    private int ticks = 0;

	void OnTriggerEnter (Collider playerSphere)
	{
        // Create force vector that will later be applied to the player
		Vector3 force = playerSphere.transform.position - transform.position;
		force = force / force.magnitude;		
		force = force * forceCoefficient;

        // Apply force vector to the player
		playerSphere.rigidbody.AddForce (force);

        // Clean up bounce node
		Destroy (gameObject);
	}

    void Update() {

        // Waits 3 ticks before destroying the bounce node
        if(ticks < 3) {
            ticks += 1;
            return;
        }
        Destroy(gameObject);
    }
}
