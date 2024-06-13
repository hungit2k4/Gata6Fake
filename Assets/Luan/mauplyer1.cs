using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mauplyer1 : MonoBehaviour
{

    public thanhmau thanhmau;
    public float nowhp;
    public float maxhp = 100;


    // Start is called before the first frame update
    void Start()
    {
        // cập nhật thanh máu 
        nowhp = maxhp;
        thanhmau.capnhatthanhmau(nowhp, maxhp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player2") {

            nowhp -= 2;
            thanhmau.capnhatthanhmau(nowhp, maxhp);

        }
    }
}
