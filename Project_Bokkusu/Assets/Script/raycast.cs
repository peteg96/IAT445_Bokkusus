using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    int layer = 1 << 8, num = 0; //ray will only interate with items in layer 8
    public GameObject spirit, UI, frontDoor, mainDoor, backDoor, leftRoom, rightRoom, mainHouse, cageSeal, clothSeal, 
        letterSeal, cage, cloth, letter, box, sprite2, bgm1, bgm2, GUI;
    public AudioClip a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12;
    float timer;
    int state = 0;
    bool start, left, right, clothCheck, letterCheck, ispause;
    AudioSource audio;
    // Start is called before the first frame update    
    void Start()
    {
        left = true;
        right = true;
        audio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //print(rightRoom.GetComponent<dooropen>().open);
        Vector3 forward = transform.TransformDirection(Vector3.forward * 2); //set the direction of the ray
        if (Physics.Raycast(transform.position, forward, 50, layer) &&
            spirit.GetComponent<Animator>().GetInteger("state") == 0 && timer == 0)
        {
            timer = 11f;
            UI.SetActive(true);
            UI.GetComponent<Type>().fullText = "Sprite:\nMy Honorable lord, I am an innocent soul imprisoned here for so long." +
                " \nHelp me, I shall lead the way.";
            audio.PlayOneShot(a1, 1);
        }
        else if (mainDoor.GetComponent<roomCheck>().inRoomCheck && num == 0)
        {
            num = 1;
            timer = 3f;
            UI.SetActive(true);
            UI.GetComponent<Type>().fullText = "Sprite:\nI'm glad you've come.";
            audio.PlayOneShot(a2, 1);
        }
        else if (mainHouse.GetComponent<roomCheck>().inRoomCheck && num == 1 && spirit.GetComponent<Animator>().GetInteger("state") == 3)
        {
            num = 2;
            timer = 5f;
            UI.SetActive(true);
            UI.GetComponent<Type>().fullText = "Sprite:\nI will be released if you complete the puzzle in each room.";
            audio.PlayOneShot(a3, 1);
        }
        else if ((leftRoom.GetComponent<dooropen>().open && left))
        {
            left = false;
            num++;
        }
        else if ((rightRoom.GetComponent<dooropen>().open && right))
        {
            right = false;
            num++;
        }
        else if (cageSeal.activeSelf == false && cage.GetComponent<roomCheck>().inRoomCheck && state == 3)
        {
            GUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                GUI.SetActive(false);
                state = 4;
                timer = 30f;
                audio.PlayOneShot(a9, 1);
                UI.SetActive(true);
                UI.GetComponent<Type>().fullText = "Sprite:\nI hate this tenebrous cage, but somehow I feel familiar with it... \nPlease forgive me, my lord.";
            }
        }
        else if (state == 4 && timer < 16)
        {
            state = 5;
            UI.GetComponent<Type>().fullText = "\nI was prisoned, locked in it for so long without seeing my love. \nThis is only because of the stupid class gap between our families.";
        }
        else if (clothSeal.activeSelf == false && cloth.GetComponent<roomCheck>().inRoomCheck && clothCheck == false)
        {
            GUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                clothCheck = true;
                timer = 4;
                UI.SetActive(true);
                UI.GetComponent<Type>().fullText = "Sprite:\nHe used to love me wearing it so much.";
                audio.PlayOneShot(a5, 1);
                GUI.SetActive(false);
            }
        }
        else if (letterSeal.activeSelf == false && letter.GetComponent<roomCheck>().inRoomCheck && letterCheck == false)
        {
            GUI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                letterCheck = true;
                timer = 9;
                audio.PlayOneShot(a8, 1);
                UI.SetActive(true);
                UI.GetComponent<Type>().fullText = "Sprite:\nHis last letter promised to marry me when he came back,but that day never comes.";
            }
        }
        else if (state == 6 && timer < 0) StartCoroutine(finalCoroutine());
        else if (state == 7 && box.GetComponent<Transparency>().state)
        {
                bgm1.SetActive(false);
                bgm2.SetActive(true);
                state = 8;
                timer = 10f;
                audio.PlayOneShot(a11, 1);
                UI.SetActive(true);
                UI.GetComponent<Type>().fullText = "Sprite:\nThank you, my lord. \nI can finally leave here to see my love in another world.";
        }
        else if (state == 8 && timer < 0)
        {
            state = 9;

            box.SetActive(false);
            sprite2.SetActive(true);
            timer = 6;
            audio.PlayOneShot(a12, 1);
            UI.SetActive(true);
            UI.GetComponent<Type>().fullText = "Sprite:\nFarewell, My honourable lord.";
        }



        if (num == 3 && state == 0) StartCoroutine(Coroutine());
        else if (num == 4 && state == 2) StartCoroutine(Coroutine());



        if (timer > 0) timer -= Time.deltaTime;
        else if (timer < 0)
        {
            UI.GetComponent<Type>().fullText = "Sprite:";
            if (UI.GetComponent<Type>().textShow == "Sprite:") UI.SetActive(false);


            if (spirit.GetComponent<Animator>().GetInteger("state") == 0)
                spirit.GetComponent<Animator>().SetInteger("state", 1); //check animation state and is ray hit object, if yes, change state
            if (state == 5)
            {
                state = 6;
                spirit.GetComponent<Animator>().SetInteger("state", 4);
            }

            
        }


        if (frontDoor.GetComponent<dooropen>().open && spirit.GetComponent<Animator>().GetInteger("state") == 1)
        {
            spirit.GetComponent<Animator>().SetInteger("state", 3);
        }
        if (num == 3 && mainHouse.GetComponent<roomCheck>().inRoomCheck && UI.activeSelf == false && state == 1)
        {
            state = 2;
            timer = 4;
            audio.PlayOneShot(a6, 1);
            UI.SetActive(true);
            UI.GetComponent<Type>().fullText = "Sprite:\nHalfway to go, My lord.";
        }

        if (Time.timeScale == 0)
        {
            audio.Pause();
            ispause = true;
        }
        else if (ispause && Time.timeScale > 0)
        {
            ispause = false;
            audio.Play();
        }

    }

    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(4f);
        if (num == 3 && state == 0)
        {

            timer = 7f;
            UI.SetActive(true);
            UI.GetComponent<Type>().fullText = "Sprite:\nThat is unfortunate…\nI assure you the door will be open if you complete the puzzle.";
            state = 1;
            audio.PlayOneShot(a4, 1);
        }
        else if (num == 4 && state == 2)
        {
            state = 3;
            timer = 3f;
            UI.SetActive(true);
            UI.GetComponent<Type>().fullText = "Sprite:\nI am with you, My lord.";
            audio.PlayOneShot(a7, 1);

        }
    }

    IEnumerator finalCoroutine()
    {
        yield return new WaitForSeconds(2f);
        if (timer < 0 && state == 6)
        {
            state = 7;
            timer = 2f;
            audio.PlayOneShot(a10, 1);
            UI.SetActive(true);
            UI.GetComponent<Type>().fullText = "Sprite:\nHere, my lord.";
        }
    }
}
