using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class PacketDecoder
{
    private MasterClient MClient;
    private static DataInputStream ClientInput;

    public PacketDecoder(MasterClient client, DataInputStream clientInput)
    {
        ClientInput = clientInput;
        MClient = client;
    }

    public bool Login()
    {
        bool success = ClientInput.ReadBoolean();
        if(success) 
        {
            String username = ClientInput.ReadUTF();
            Debug.Log("Successfully logged in.");
            return success;
        }


        byte opcode = ClientInput.ReadByte();
        GameObject.Find("txtLoginMessage").GetComponent<Text>().text = GetLoginMessage(opcode);
        return success;
    }

    private String GetLoginMessage(byte opcode)
    {
        switch(opcode)
        {
            case 0: return "Invalid username or password.";
            case 1: return "Account is already logged in.";
            default: return "Invalid opcode sent from server.";
        }
    }
}
