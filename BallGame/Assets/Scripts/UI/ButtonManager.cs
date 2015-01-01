using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonManager : MonoBehaviour {

	private MasterClient MClient;

    void Start() 
    {
        MClient = GameObject.Find("MasterClient").GetComponent<MasterClient>();
    }

    public void SendLogin()
    {
        InputField[] loginData = GameObject.Find("LoginCanvas").GetComponentsInChildren<InputField>();
        string username = loginData[0].value;
        string password = loginData[1].value;

        MClient.Sendpacket(0, username + "~" + password);
    }
}
