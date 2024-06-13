using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpboss : MonoBehaviour
{

    public int hpbosss = 100;
    public int nowhp;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (hpbosss < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "bullet")
        {
            hpbosss -=10;
        }
       
    }
}
