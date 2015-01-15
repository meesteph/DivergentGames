using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public float TapForceCoefficient;
    private float ballScale;
    private Vector3 currentPos;

    void Start()
    {
        ballScale = Screen.height/8.0f;
        gameObject.transform.localScale = new Vector3(ballScale, ballScale, ballScale);
    }

    void Update()
    {
        // Check if out of bounds
        if(transform.localPosition.x >= Screen.width/2 || 
           transform.localPosition.x <= -Screen.width/2 ||
           transform.localPosition.y >= (Screen.height/2 + WorldScript.verticalOffset))
        {
            transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        } else if (transform.localPosition.y <= -Screen.height/2)
        {
            playerDie.HandleDeath();
        }

        currentPos = transform.localPosition;
        // Check if outside z-plane

        /*if(currentPos.z > 1 || currentPos.z < 1)
        {
            gameObject.transform.localPosition =new Vector3(currentPos.x, currentPos.y, 0);
        }*/

		if (currentPos.z != ballScale * 1.1f) {
			gameObject.transform.localPosition = new Vector3 (currentPos.x, currentPos.y, ballScale * 1.1f);

		
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
