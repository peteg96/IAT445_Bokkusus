using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropen : MonoBehaviour
{
    public Animator doorL, doorR;
    // Start is called before the first frame update
    void Start()
    {
        //doorL = GetComponent<Animator>();
        //doorR = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            //print(doorLeft.SetInteger("state"));
            doorL.SetInteger("state", 1);
            doorR.SetInteger("state", 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            doorL.SetInteger("state", -1);
            doorR.SetInteger("state", -1);
        }
    }
}
