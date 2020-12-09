﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCamera : MonoBehaviour
{
    public GameObject Player, state_left, state_right;
    public GameObject Camera;
    
    bool reveal = false;
    float time_left = 5.0f, time_right = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        Player.GetComponent<Camera>().gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (state_left.GetComponent<state_detector>().num == 6 && time_left > 0)
        {

            //reveal the result and the camera switch 
            Player.GetComponent<Camera>().gameObject.SetActive(false);
            Camera.GetComponent<Camera>().gameObject.SetActive(true);
            time_left -= Time.deltaTime;
        }
        else if(state_right.GetComponent<game_light>().state == true && time_right > 0)
        {
            Player.GetComponent<Camera>().gameObject.SetActive(false);
            Camera.GetComponent<Camera>().gameObject.SetActive(true);
            Camera.GetComponent<Animator>().SetBool("state", true);
            time_right -= Time.deltaTime;
        }
        else
        {
            //switch back to player perspective
            Camera.GetComponent<Camera>().gameObject.SetActive(false);
            Player.GetComponent<Camera>().gameObject.SetActive(true);

        }
    }
}
