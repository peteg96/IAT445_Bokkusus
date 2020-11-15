using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    private bool state, grabable = true, triggered;
    public GameObject holder, texts, lights;
    void Start()
    {
        
    }

    void Update()
    {
        if (grabable)
        {
            if (state)
            {
                this.GetComponent<Rigidbody>().useGravity = false;
                this.GetComponent<BoxCollider>().enabled = false;
                this.transform.localRotation = holder.transform.rotation;
                this.transform.position = holder.transform.position;
            }
            else
            {
                this.GetComponent<Rigidbody>().useGravity = true;
                this.GetComponent<BoxCollider>().enabled = true;
            }
            if (Input.GetMouseButton(0) == false) state = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "base1" && Input.GetMouseButton(0) == false && triggered == false)
        {
            this.transform.position = new Vector3(28, this.transform.position.y, 35);
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<BoxCollider>().enabled = true;
            triggered = true;
            texts.SetActive(true);
            lights.SetActive(true);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
        if (other.tag == "Player")
        {
            print(Input.GetMouseButton(0));
            if (Input.GetMouseButton(0)) state = true;
        }
        if (other.tag == "base1" && triggered)
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 4.8f, ForceMode.Acceleration);
            grabable = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.tag == "base1") triggered = false;
    }
}
