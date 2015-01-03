using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Parse;
using System;

public class RegisterButtonManager : MonoBehaviour {

    public void RegisterButtonClicked()
    {
         Application.LoadLevel ("RegisterScene");
    }
}
