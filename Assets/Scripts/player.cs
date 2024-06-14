using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class player : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!IsOwner)
        {
            return;
        }
        transform.position = new Vector3(21.02964f, -0.749f, 42.03304f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
        {
            return;
        }
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate the move direction
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.position += move*Time.deltaTime*5;
    }
}
