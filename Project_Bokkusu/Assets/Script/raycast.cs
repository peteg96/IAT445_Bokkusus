using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    int layer = 1 << 8, num = 0; //ray will only interate with items in layer 8
    public GameObject spirit, UI, frontDoor, mainDoor, leftRoom, rightRoom;
    float timer;
    bool start;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(timer);
        Vector3 forward = transform.TransformDirection(Vector3.forward * 2); //set the direction of the ray
        if (Physics.Raycast(transform.position, forward, 50, layer) &&
            spirit.GetComponent<Animator>().GetInteger("state") == 0)
        {
            timer = 11f;
            UI.SetActive(true);
            UI.GetComponent<Type>().fullText = "Sprite:\nMy Honorable lord, I am an innocent soul imprisoned here for so long." +
                " \nHelp me, I shall lead the way.";
        }
        else if (mainDoor.GetComponent<roomCheck>().inRoomCheck && num == 0)
        {
            num = 1;
            timer = 3f;
            UI.SetActive(true);
            UI.GetComponent<Type>().fullText = "Sprite:\nI'm glad you've come.";
        }
        else if (leftRoom.GetComponent<roomCheck>().inRoomCheck || rightRoom.GetComponent<roomCheck>().inRoomCheck)
        {
            
            if (num == 1)
            {
                num = 2;
                timer = 7f;
                UI.SetActive(true);
                UI.GetComponent<Type>().fullText = "Sprite:\nThat is unfortunate…\nI assure you the door will be open if you complete the puzzle.";
            }
        }


        if(timer > 0) timer -= Time.deltaTime;
        else if (timer < 0)
        {
            UI.GetComponent<Type>().fullText = "Sprite:";
            if (UI.GetComponent<Type>().textShow == "Sprite:") UI.SetActive(false);
            if (spirit.GetComponent<Animator>().GetInteger("state") == 0)
            spirit.GetComponent<Animator>().SetInteger("state", 1); //check animation state and is ray hit object, if yes, change state
        }


        if (frontDoor.GetComponent<dooropen>().open && spirit.GetComponent<Animator>().GetInteger("state") == 1)
        {
            spirit.GetComponent<Animator>().SetInteger("state", 3);
        }

    }
}
