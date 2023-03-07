using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System;
using System.Linq;
using Newtonsoft.Json;
public class Connection : MonoBehaviour
{
    TcpClient client;
    StreamReader reader;
    StreamWriter writer;
    Thread receiveThread;
    public ControllerModule playerController;
    // Start is called before the first frame update
    void Start()
    {
        client = new TcpClient("localhost", 8080);
        reader = new StreamReader(client.GetStream());
        writer = new StreamWriter(client.GetStream());
        Debug.Log("Connected to server");
    }

    
    void Update()
    {
        if (client.Available > 0)
            {
                // Read the data from the server
                string data = reader.ReadLine();
                
                if (data!= null){
                // Debug.Log("Received data from server: " + data);
                    Dictionary<string, float[]> td = processData(data);
                    playerController.updatePosition(td);
                    
                }
            }
    }



    Dictionary<string, float[]>  processData(string jsonString){

        Dictionary<string, float[]> dict = JsonConvert.DeserializeObject<Dictionary<string, float[]>>(jsonString);
        
        return dict;
    }
  

    private void OnApplicationQuit()
    {
        // Close the connection to the server when the application is closed
        reader.Close();
        writer.Close();
        client.Close();

        // Stop the receive thread
        if (receiveThread != null)
        {
            receiveThread.Abort();
        }
    }
}
