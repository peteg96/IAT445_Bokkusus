using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject uiButtons, controller;
    bool state;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(state);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            uiButtons.SetActive(true);
            Time.timeScale = 0f;
            controller.GetComponent<FirstPersonController>().enabled = false;
        }

        if (state)
        {

            state = false;
            uiButtons.SetActive(false);
            controller.GetComponent<FirstPersonController>().enabled = true;
        }
    }



    public void resume()
    {
        Time.timeScale = 1.0f;
        state = true;
    }

    public void quit()
    {
        Application.Quit();
    }
}
