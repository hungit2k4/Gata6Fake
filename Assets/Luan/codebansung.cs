using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class codebansung : MonoBehaviour
{
    public Transform t�m;
    public Transform s�ng; // Transform where the bullet spawns
    public Transform gocnhin; // Transform where the bullet spawns
    public TextMeshPro loadsodan;


    public GameObject ak47;

    public int sodan;

    bool fag = false;


    public GameObject bulletPrefab; // Reference to the bullet prefab
    public float bulletSpeed = 20f; // Speed of the bullet
    int forceMultiplier = 10;

    float fireRate = 0.1f; // Time between shots in seconds (adjust for desired rate)

    private float nextFireTime = 0f; // Time when the next bullet can be fired

    //private Animator animator;

    private void Start()
    {
        sodan = 30;
       // animator = GetComponent<Animator>();
    }

    private void Update()
    {

        // dang ban
        bool isfire = Input.GetMouseButton(0);


        // nap dan
        if (Input.GetKey(KeyCode.R) && isfire == false)
        {
         //   animator.SetBool("bansung", false);

          //  animator.SetBool("bo", true);
            Invoke("huynapdan", 2f);

        }
        // Check if left mouse button is held down
        if (Input.GetMouseButton(0) && sodan > 0 && Time.time >= nextFireTime)
        {
          //  animator.SetBool("banmark", true);

            // Fire a bullet

            FireBullet();
            // Update next fire time based on fire rate
            nextFireTime = Time.time + fireRate;
          //  AimGunAtTarget();

        }

        else if (isfire == false)
        {
           // animator.SetBool("banmark", false);

        }

        else if (sodan <= 0) // Reset animation trigger when not holding
        {


           // animator.SetBool("bansung", false);
        }

    }




    private void OnTriggerEnter(Collider other)
    {






        if (other.gameObject.tag == "ak")
        {


            ak47.SetActive(true);
            Destroy(other.gameObject);








        }
        else
        {
            fag = false;

        }
    }
    void huynapdan()
    {
      //  animator.SetBool("bo", false);
        sodan = 30;
        loadsodan.text = "" + sodan;


    }
    private void FireBullet()
    {
        // Instantiate a bullet from the prefab
        GameObject bullet = Instantiate(bulletPrefab, s�ng.position, s�ng.rotation);

        // Apply forward force to the bullet
        bullet.GetComponent<Rigidbody>().AddForce(s�ng.forward * bulletSpeed * forceMultiplier, ForceMode.Impulse);
        sodan -= 1;

        loadsodan.text = "" + sodan;
    }

   // private void AimGunAtTarget()
   // {
        //  Calculate the direction from the gun to the aim point
   //     Vector3 direction = t�m.position - gocnhin.position;

        // Rotate the gun to face the direction (ignoring up/down rotation)
   //     gocnhin.rotation = Quaternion.LookRotation(direction, Vector3.forward);
   // }


}
