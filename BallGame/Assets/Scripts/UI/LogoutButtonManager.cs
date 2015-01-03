using UnityEngine;
using System.Collections;
using Parse;

public class LogoutButtonManager : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
	   if (ParseUser.CurrentUser != null)
        {
            // do stuff with the user
        }
        else
        {
            Application.LoadLevel ("LoginScene");
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	   
	}

    public void Logout()
    {
        ParseUser.LogOut();
        Start();
    }
}
