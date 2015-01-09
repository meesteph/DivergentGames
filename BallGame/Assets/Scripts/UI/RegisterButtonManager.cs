using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Parse;
using System;

public class RegisterButtonManager : MonoBehaviour {

    private InputField[] loginData;
    public static string username = string.Empty;

    void Start()
    {
        loginData = GameObject.Find("LoginPanel").GetComponentsInChildren<InputField>();
    }

    public void RegisterButtonClicked()
    {
        username = loginData[0].text;
        Application.LoadLevel ("RegisterScene");
    }
}
