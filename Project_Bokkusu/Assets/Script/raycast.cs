using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    int layer = 1 << 8; //ray will only interate with items in layer 8
    public GameObject spirit, UI;
    float timer = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward * 2); //set the direction of the ray
        if (Physics.Raycast(transform.position, forward, 50, layer) &&
            spirit.GetComponent<Animator>().GetInteger("state") == 0)
        {
            timer -= Time.deltaTime;
            UI.SetActive(true);
        }
            
            

        //if (Physics.Raycast(transform.position, forward, 50, layer) && spirit.GetComponent<Transform>().position == new Vector3((float)19.5, (float)1.8682, (float)13.44))spirit.GetComponent<Animator>().SetInteger("state", 2); // check is object reach the position, if yes, change state

        if (timer < 0) spirit.GetComponent<Animator>().SetInteger("state", 1); //check animation state and is ray hit object, if yes, change state

    }
}
