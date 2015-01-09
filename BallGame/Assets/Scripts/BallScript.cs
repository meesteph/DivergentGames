using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public float TapForceCoefficient;

    void Update()
    {
        // Check if out of bounds
        if(transform.localPosition.x >= Screen.width/2 || 
           transform.localPosition.x <= -Screen.width/2 ||
           transform.localPosition.y >= (Screen.height/2 + WorldScript.verticalOffset))
        {
            transform.localPosition =new Vector3(0.0f, 0.0f, 0.0f);
        } else if (transform.localPosition.y <= -Screen.height/2)
        {
            playerDie.PauseGame();
        }
    }

	void OnMouseDown()
	{
		Vector3 force = -(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.localPosition);
		force = force / force.magnitude;
		force = force * TapForceCoefficient;
		rigidbody.AddForce (force.x, force.y, 0.0f);
		rigidbody.angularVelocity = force;

	}

}
