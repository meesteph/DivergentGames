using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class MasterClient : MonoBehaviour 
{

    public static MasterClient Singleton;

    // Networking variables
    private const int PORT = 5055;
    private static TcpClient Client;
    private static NetworkStream Stream;
    private static BinaryWriter ClientWriter;
    private static BinaryReader ClientReader;
    private static DataOutputStream ClientOutput;
    private static DataInputStream ClientInput;
    private static PacketEncoder PacketsOut;
    private static PacketDecoder PacketsIn;

    private static Thread InputListener;

    void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(this);
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if(Client == null)
        {
            Connect(); 
        }

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Client.Close();
        }
    }

    public void Connect()
    {
        Client = new TcpClient();
        try
        {
            Client.Connect(IPAddress.Parse("127.0.0.1"), PORT);
            Stream = Client.GetStream();
            ClientWriter = new BinaryWriter(Stream);
            ClientReader = new BinaryReader(Stream);
            ClientOutput = new DataOutputStream(ClientWriter);
            ClientInput = new DataInputStream(ClientReader);
            PacketsOut = new PacketEncoder(ClientOutput);
            PacketsIn = new PacketDecoder(this, ClientInput);

            PacketsOut.SendLogin("Admin", "Bob12");

            InputListener = new Thread(new ThreadStart(InputLoop));
            InputListener.Start();
        }
        catch(Exception e)
        {
            Debug.LogException(e);
        }
    }

    public void SendPacket(byte PacketID, string data)
    {
        string[] packetData = data.Split('~');
        switch(packetID)
        {
            case 0: // Login
                PacketsOut.SendLogin(packetData[0], packetData[1]);
                break;
        }
    }

    void InputLoop()
    {
        while(Client.Connected)
        {
            byte packetID = ClientInput.ReadByte();
            switch(packetID)
            {
                case 0: // Login
                    PacketsIn.Login();
                    break;

                case 1:
                    break;

                case 2:
                    break;
            }
        }
    }

    void OnApplicationQuit()
    {
        Client.Close();
    }
}
