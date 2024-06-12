using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class RenderCam : NetworkBehaviour
{
    // Start is called before the first frame update
    private Camera playerCamera;
    void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();

        // Chỉ kích hoạt camera nếu đối tượng player này thuộc về local player
        if (IsOwner)
        {
            playerCamera.enabled = true;
        }
        else
        {
            playerCamera.enabled = false;
        }
    }

}
