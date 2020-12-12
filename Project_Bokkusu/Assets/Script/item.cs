using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    private bool state, grabable = true, triggered;
    public GameObject holder, texts, lights, GUI2;
    public AudioClip drop;
    void Start()
    {
        
    }

    void Update()
    {
        if (grabable)
        {
            
            if (state)
            {
                GUI2.SetActive(false);
                this.GetComponent<Rigidbody>().useGravity = false;
                this.GetComponent<BoxCollider>().enabled = false;
                
                this.transform.position = holder.transform.position;
                this.transform.rotation = holder.transform.rotation;
            }
            else
            {
                this.GetComponent<Rigidbody>().useGravity = true;
                this.GetComponent<BoxCollider>().enabled = true;
            }
            if (Input.GetMouseButton(0) == false)
            {
                state = false;
                holder.GetComponent<state_detector>().isholding = false;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ground" && Input.GetMouseButton(0) == false) this.GetComponent<AudioSource>().PlayOneShot(drop, 0.1f);
        if (other.tag == "Player" && holder.GetComponent<state_detector>().isholding == false && grabable) GUI2.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == this.tag && Input.GetMouseButton(0) == false && triggered == false)
        {
            this.transform.position = new Vector3(other.transform.position.x, 2, other.transform.position.z);
            this.transform.rotation = new Quaternion(0, 90, 0, 0);
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<BoxCollider>().enabled = true;
            triggered = true;
            holder.GetComponent<state_detector>().num += 1;
            texts.SetActive(true);
            lights.SetActive(true);
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
        if (other.tag == "Player" && holder.GetComponent<state_detector>().isholding == false)
        {
            if (Input.GetMouseButton(0)) state = true;
            holder.GetComponent<state_detector>().isholding = true;

        }
        if (other.tag == this.tag && triggered)
        {
            this.GetComponent<Rigidbody>().AddForce(Vector3.up * 4.8f, ForceMode.Acceleration);
            grabable = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player") GUI2.SetActive(false);
    }
}
