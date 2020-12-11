using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropen : MonoBehaviour
{
    public Animator doorL, doorR;
    public GameObject lefthouse, leftGame, rightthouse, character, mainhouse;
    public bool open;
    //private int left = 0, right = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (this.tag == "LeftDoor")
        {
            if (lefthouse.GetComponent<roomCheck>().inRoomCheck == false)
            {
                doorL.SetInteger("state", 1);
                doorR.SetInteger("state", 1);
            }
        }
        else if (this.tag == "RightDoor")
        {
            if (rightthouse.GetComponent<roomCheck>().inRoomCheck == false)
            {
                doorL.SetInteger("state", 1);
                doorR.SetInteger("state", 1);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(leftGame.GetComponent<game_light>().state && this.tag == "LeftDoor")
        {
            doorL.SetInteger("state", 1);
            doorR.SetInteger("state", 1);
        }
        if (character.GetComponent<state_detector>().num == 6 && this.tag == "RightDoor")
        {
            doorL.SetInteger("state", 1);
            doorR.SetInteger("state", 1);
        }
        if (this.tag == "BackDoor" && character.GetComponent<state_detector>().num == 6 && leftGame.GetComponent<game_light>().state)
        {
            doorL.SetInteger("state", 1);
            doorR.SetInteger("state", 1);
        }

        if (this.tag == "LeftDoor")
        {
            if (lefthouse.GetComponent<roomCheck>().inRoomCheck)
            {
                open = true;
            }
        }
        if (this.tag == "RightDoor")
        {
            if (rightthouse.GetComponent<roomCheck>().inRoomCheck) open = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (this.tag == "LeftDoor")
            {
                if (lefthouse.GetComponent<roomCheck>().inRoomCheck == false)
                {
                    doorL.SetInteger("state", 1);
                    doorR.SetInteger("state", 1);
                }
            }
            else if (this.tag == "RightDoor")
            {
                if (rightthouse.GetComponent<roomCheck>().inRoomCheck == false)
                {
                    doorL.SetInteger("state", 1);
                    doorR.SetInteger("state", 1);
                }
            }
            else if (this.tag == "fontDoor")
            {
                if (mainhouse.GetComponent<roomCheck>().inRoomCheck == false)
                {
                    doorL.SetInteger("state", 1);
                    doorR.SetInteger("state", 1);
                    open = true;
                }
            }
            else if (this.tag == "BackDoor") { }
            else
            {
                doorL.SetInteger("state", 1);
                doorR.SetInteger("state", 1);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            doorL.SetInteger("state", -1);
            doorR.SetInteger("state", -1);
            open = false;
        }
    }
}
