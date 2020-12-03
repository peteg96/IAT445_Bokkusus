using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCamera : MonoBehaviour
{
    public GameObject Player;
    public GameObject Camera;
    
    bool reveal = false;
    int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player.GetComponent<Camera>().gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (x % 200==0)
        {
            if (reveal == true)
            {
                reveal = false;
            }
            else reveal = true;
        }
        if (reveal == true)
        {
            //reveal the result and the camera switch 
            Player.GetComponent<Camera>().gameObject.SetActive(false);
            Camera.GetComponent<Camera>().gameObject.SetActive(true);
            //cam_p.gameObject.SetActive(false);
            //cam_c.gameObject.SetActive(true);
        }
        else
        {
            //switch back to player perspective
            Camera.GetComponent<Camera>().gameObject.SetActive(false);
            Player.GetComponent<Camera>().gameObject.SetActive(true);
            //cam_p.gameObject.SetActive(true);
            //cam_c.gameObject.SetActive(false);
        }
        x++;
        print(x);
    }
}
