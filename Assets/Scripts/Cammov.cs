using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Cammov : NetworkBehaviour
{
    // Start is called before the first frame update
    public float mouseSensitivity = 100f;

    float xRotation = 0f;
    float yRotation = 0f;

    GameObject cam;
    void Start()
    {
        // Chỉ thực hiện các thiết lập này nếu đối tượng này thuộc về local player
        if (IsOwner)
        {
            Cursor.lockState = CursorLockMode.Locked;
            cam= transform.GetChild(0).gameObject;

        }
    }

    void Update()
    {
        // Chỉ điều khiển camera nếu đối tượng này thuộc về local player
        if (!IsOwner)
        {
            return;
        }

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
           // Thêm giá trị quay theo trục Y

            // Giới hạn góc quay của trục X
            xRotation = Mathf.Clamp(xRotation, -20f, 20f);

            // Sử dụng cả hai giá trị xRotation và yRotation để quay camera
            cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
            if (IsClient)
            {
                transform.Rotate(Vector3.up * mouseX);
            }
        }

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
