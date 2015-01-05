using UnityEngine;
using System.Collections;

public class RecognizeMouseClick : MonoBehaviour {

	public float TapForceCoefficient;

	void OnMouseDown()
	{
		Vector3 force = -(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.localPosition);
		force = force / force.magnitude;
		force = force * TapForceCoefficient;
		rigidbody.AddForce (force.x, force.y, 0.0f);
		rigidbody.angularVelocity = force;

	}

}
