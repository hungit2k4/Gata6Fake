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
using UnityEngine.SceneManagement;

public class UINetworkManager : MonoBehaviour
{
    public static string hostCode;
    private void Start()
    {
        StartCoroutine(StartSever());
    }
    private IEnumerator StartSever()
    {
        yield return new WaitForSeconds(1f);
        string ipv4 = "";
        int x = GameSession.x;
        ipv4 = GameSession.ipv4;
        if (x==0)
        {
            hostCode = GenerateHostCode();
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ipv4, 7777);
            NetworkManager.Singleton.StartHost();
            Debug.Log("hostCode:"+hostCode);
        }else if (x==1)
        {
            //if(GameSession.hostCode==hostCode)
           // {
                NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ipv4, 7777); // Sử dụng địa chỉ IPv4 và cổng của máy chủ
                NetworkManager.Singleton.StartClient();
           // }
            //else
            //{
            //    Debug.Log("code not found");
           // }
            
        }
        else
        {
            hostCode = GenerateHostCode();
            NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ipv4, 7777); // Sử dụng cổng của máy chủ
            NetworkManager.Singleton.StartServer();
        }
        
        
        
    }
    private string GenerateHostCode()
    {
        return Random.Range(1000, 9999).ToString(); // Tạo mã code ngẫu nhiên từ 1000 đến 9999
    }


}