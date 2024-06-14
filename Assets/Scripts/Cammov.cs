/*using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Cammov : NetworkBehaviour
{
    // Start is called before the first frame update
    public float mouseSensitivity = 100f;

    float xRotation = 0f;


    GameObject cam;
    void Start()
    {
        // Chỉ thực hiện các thiết lập này nếu đối tượng này thuộc về local player
       // StartCoroutine(Getcam());
        if (IsOwner)
        {
            Cursor.lockState = CursorLockMode.Locked;
            cam = transform.GetChild(0).gameObject;

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
    private IEnumerator Getcam()
    {
        yield return new WaitForSeconds(3f);
        
    }
}*/
using Unity.Netcode;
using UnityEngine;

public class Cammov : NetworkBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        if (!IsOwner)
        {
            Destroy(gameObject);
            Debug.Log("dgd");
            return;

        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (!IsOwner) return;
        if(Cursor.lockState == CursorLockMode.Locked)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -30f, 30f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.lockState = CursorLockMode.None;
        }if (Input.GetKey(KeyCode.Mouse0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
            
    }
}
