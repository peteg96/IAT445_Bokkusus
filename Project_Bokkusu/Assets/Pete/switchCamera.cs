using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCamera : MonoBehaviour
{
    public GameObject Player, state_left, state_right, box, sealL, sealR;
    public GameObject Camera, GUI, cL, cR;
    
    
    float time_left = 8.0f, time_right = 8.0f;
    // Start is called before the first frame update
    void Start()
    {
        Player.GetComponent<Camera>().gameObject.SetActive(true);
        GUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (state_left.GetComponent<state_detector>().num == 6 && time_left > 7) time_left -= Time.deltaTime;
        else if (state_left.GetComponent<state_detector>().num == 6 && time_left > 4)
        {
            Player.GetComponent<Camera>().gameObject.SetActive(false);
            cL.GetComponent<Camera>().gameObject.SetActive(true);
            sealL.GetComponent<Animator>().SetBool("state", true);
            time_left -= Time.deltaTime;
        }
        else if (state_left.GetComponent<state_detector>().num == 6 && time_left > 0)
        {

            //reveal the result and the camera switch 
            sealL.SetActive(false);
            cL.GetComponent<Camera>().gameObject.SetActive(false);
            Camera.GetComponent<Camera>().gameObject.SetActive(true);

            time_left -= Time.deltaTime;
            if (time_left < 2f) box.GetComponent<Animator>().SetBool("shake", true);

        }
        else if (state_right.GetComponent<game_light>().state == true && time_right > 7)
        {
            GUI.SetActive(false);
            time_right -= Time.deltaTime;
        }
        else if (state_right.GetComponent<game_light>().state == true && time_right > 4)
        {
            Player.GetComponent<Camera>().gameObject.SetActive(false);
            cR.GetComponent<Camera>().gameObject.SetActive(true);
            sealR.GetComponent<Animator>().SetBool("state", true);
            time_right -= Time.deltaTime;
        }
        else if (state_right.GetComponent<game_light>().state == true && time_right > 0)
        {
            sealR.SetActive(false);
            cR.GetComponent<Camera>().gameObject.SetActive(false);
            Camera.GetComponent<Camera>().gameObject.SetActive(true);
            Camera.GetComponent<Animator>().SetBool("state", true);
            time_right -= Time.deltaTime;
            if (time_right < 2f) box.GetComponent<Animator>().SetBool("shake", true);
        }
        else
        {
            //switch back to player perspective
            Camera.GetComponent<Camera>().gameObject.SetActive(false);
            Player.GetComponent<Camera>().gameObject.SetActive(true);
            box.GetComponent<Animator>().SetBool("shake", false);
        }
    }
}
