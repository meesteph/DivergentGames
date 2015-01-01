using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PacketEncoder 
{
    private static DataOutputStream ClientOutput;

    public PacketEncoder(DataOutputStream clientOutput)
    {
        ClientOutput = clientOutput;
    }

    public void SendLogin(string username, string password)
    {
        Debug.Log("Username: {"+username+"} || Password: {"+password+"}");
        ClientOutput.WriteUTF(username);
        ClientOutput.WriteUTF(password);
        ClientOutput.Flush();
    }
}
