using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using Unity.Netcode.Transports.UTP;

public class UIStartManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject joinPanel;
    [SerializeField] TMP_InputField inputIPV4;
    [SerializeField] TMP_InputField inputHostCode;

    public void ShowJoinPanel(bool isShow)
    {
        menuPanel.SetActive(isShow);
        joinPanel.SetActive(!isShow);
    }
    public void LoadScreen(int x)
    {
        if (x == 0)
        {
            SceneManager.LoadScene(1);
            GameSession.ipv4 = inputIPV4.text;
            GameSession.x = x;
        }
        if (x == 1&& inputHostCode.text!="")
        {
            SceneManager.LoadScene(1);
            GameSession.ipv4 = inputIPV4.text;
            GameSession.x = x;
            GameSession.hostCode=inputHostCode.text;
        }
        
    }
}
