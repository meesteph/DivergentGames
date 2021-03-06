﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Parse;
using System;

public class LoginButtonManager : MonoBehaviour {

	//private MasterClient MClient;
    Text displayError;
    private string errorText = string.Empty;
    public static float highA;
    public static float highB;
    public static float highC;
    private InputField[] loginData;
    private string username = string.Empty;

    void Start() 
    {
        loginData = GameObject.Find("LoginPanel").GetComponentsInChildren<InputField>();
        displayError = GameObject.Find("txtLoginMessage").GetComponent<Text>();
        Time.timeScale = 1;
    }

    void Update()
    {
        displayError.text = errorText;
        if (ParseUser.CurrentUser != null)
        {
            errorText = "Loading game...";
            Application.LoadLevel ("SettingsScene");
        }   
        else
        {
            // show the signup or login screen
        }
    }

    public void SendLogin()
    {
        errorText = "Logging in...";
        username = loginData[0].text;
        string password = loginData[1].text;

        ParseUser.LogInAsync(username, password).ContinueWith(t =>
        {
            if (t.IsFaulted)
            {
                // The login failed. Check the error to see why.
                errorText = "Username/Password combination does not exist.";
                //displayError.
            } else if (t.IsCanceled)
            {
                Debug.Log("Canceled");
            }
            else
            {
                errorText = "Login successful: loading game...";
            }
        });
    }
}
