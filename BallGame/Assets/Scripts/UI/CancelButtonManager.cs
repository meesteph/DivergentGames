using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Parse;
using System;

public class CancelButtonManager : MonoBehaviour {

    public void CancelButtonClicked()
    {
         Application.LoadLevel ("LoginScene");
    }
}
