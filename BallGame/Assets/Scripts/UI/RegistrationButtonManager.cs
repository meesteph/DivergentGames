using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Parse;
using System;
using System.IO;
using System.Threading.Tasks;

public class RegistrationButtonManager : MonoBehaviour {

    Text displayError;
    private string errorText = string.Empty;
    public static string username = string.Empty;
    private string password = string.Empty;
    private string email = string.Empty;
    private string lastEmail = string.Empty;
    private InputField[] registrationData;

	// Use this for initialization
	void Start () {
        registrationData = GameObject.Find("RegistrationPanel").GetComponentsInChildren<InputField>();
        registrationData[0].text = RegisterButtonManager.username;

        displayError = GameObject.Find("txtLoginMessage").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        displayError.text = errorText;
        if (ParseUser.CurrentUser != null)
        {
            Application.LoadLevel ("SettingsScene");
        }
        else
        {
            // Application.LoadLevel ("LoginScene");
        }
	}

    public void SendRegistration()
    {
        errorText = "Registering...";

        username = registrationData[0].text;
        password = registrationData[1].text;
        email = registrationData[2].text;

        var user = new ParseUser()
        {
            Username = username,
            Password = password,
            Email = email
        };

        // Check for username in database: don't allow registration if it already exists
        ParseUser.Query.WhereEqualTo("username", username).FindAsync().ContinueWith(findTask => 
        {
            if (findTask.IsFaulted)
            {
                // something went wrong with the Find
                AggregateException ae = findTask.Exception;
                if( ae != null)
                {
                    Debug.Log("An exception occurred: " + ae.InnerException.Message);
                                        
                    foreach(var e in findTask.Exception.InnerExceptions) 
                    {
                        ParseException parseException = (ParseException) e;
                        
                        Debug.Log("Error message " + parseException.Message);
                        Debug.Log("Error code: " + parseException.Code);
                    }
                }
            }
            else if(findTask.IsCompleted)
            {
                // the task has been successful, now we need to know if Result returned even a single value
                int numEntries = 0;
                foreach(ParseUser parseUser in findTask.Result)
                {
                    Debug.Log("User found: " + parseUser.Username);
                    
                    numEntries++;

                    errorText = "An account with this username already exists.";
                }
            }
        });

        // Check for email in database: don't allow registration if it already exists
        ParseUser.Query.WhereEqualTo("email", email).FindAsync().ContinueWith(findTask => 
        {
            if (findTask.IsFaulted)
            {
                // something went wrong with the Find
                AggregateException ae = findTask.Exception;
                if( ae != null)
                {
                    Debug.Log("An exception occurred: " + ae.InnerException.Message);
                                        
                    foreach(var e in findTask.Exception.InnerExceptions) 
                    {
                        ParseException parseException = (ParseException) e;
                        
                        Debug.Log("Error message " + parseException.Message);
                        Debug.Log("Error code: " + parseException.Code);
                    }
                }
            }
            else if(findTask.IsCompleted)
            {
                // the task has been successful, now we need to know if Result returned even a single value
                int numEntries = 0;
                foreach(ParseUser parseUser in findTask.Result)
                {
                    Debug.Log("Email found: " + parseUser.Email);
                    
                    numEntries++;

                    errorText = "An account with this e-mail already exists.";
                    lastEmail = email;
                    return;
                }
            }
        });

        if(username == string.Empty)
        {
            errorText = "You must enter a username.";
        } else if(password == string.Empty) {
            errorText = "You must enter a password.";
        } else if(email == string.Empty) {
            errorText = "You must enter an e-mail.";
        } else {
            try
            {
                user.SignUpAsync().ContinueWith(t => {
                    if (t.IsFaulted && email != lastEmail) {
                        // Errors from Parse Cloud and network interactions
                        using (IEnumerator<System.Exception> enumerator = t.Exception.InnerExceptions.GetEnumerator()) {
                            if (enumerator.MoveNext()) {
                                ParseException error = (ParseException) enumerator.Current;
                                Debug.Log(error.Message);
                                Debug.Log(error.Code);
                                errorText = "A valid e-mail address is required.";
                            }
                        }
                    }
                });
            }
            catch (InvalidOperationException e)
            {
                Debug.Log(e.Message);
            }  
        }
    } 
}
