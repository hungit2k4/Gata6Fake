/*using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class UINetworkManager : MonoBehaviour
{
    void OnGUI()
     {
         GUILayout.BeginArea(new Rect(10, 10, 300, 300));
         if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
         {
             StartButtons();
         }
         else
         {
             StatusLabels();


         }

         GUILayout.EndArea();
     }

     static void StartButtons()
     {

         if (GUILayout.Button("Host")) NetworkManager.Singleton.StartHost();
         if (GUILayout.Button("Client")) NetworkManager.Singleton.StartClient();
         if (GUILayout.Button("Server")) NetworkManager.Singleton.StartServer();
     }

     static void StatusLabels()
     {
         var mode = NetworkManager.Singleton.IsHost ?
             "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";

         GUILayout.Label("Transport: " +
             NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
         GUILayout.Label("Mode: " + mode);
     }
   
  
}*/
 



using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

using Unity.Netcode.Transports.UTP;

public class UINetworkManager : MonoBehaviour
{

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            StartButtons();
        }
        else
        {
            StatusLabels();
        }
        GUILayout.EndArea();
    }

    static void StartButtons()
    {
        if (GUILayout.Button("Host"))
        {
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData("192.168.1.21", 7777);
            NetworkManager.Singleton.StartHost();
        }

        if (GUILayout.Button("Client"))
        {
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData("192.168.1.21", 7777); // Sử dụng địa chỉ IPv4 và cổng của máy chủ
            NetworkManager.Singleton.StartClient();
        }

        if (GUILayout.Button("Server"))
        {
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData("192.168.1.21", 7777); // Sử dụng cổng của máy chủ
            NetworkManager.Singleton.StartServer();
        }
    }

    static void StatusLabels()
    {
        var mode = NetworkManager.Singleton.IsHost ?
            "Host" : NetworkManager.Singleton.IsServer ? "Server" : "Client";
        GUILayout.Label("Transport: " +
            NetworkManager.Singleton.NetworkConfig.NetworkTransport.GetType().Name);
        GUILayout.Label("Mode: " + mode);
    }
}