using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_light : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    public GameObject light5;
    public GameObject light6;
    public GameObject light7;
    public GameObject light8;
    public GameObject light9;
    public bool state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((!light1.activeSelf && light2.activeSelf && light3.activeSelf && light4.activeSelf && !light5.activeSelf 
                 && !light6.activeSelf  && !light7.activeSelf  && light8.activeSelf && light9.activeSelf)==true)
        {
            state = true;
        }
    }
}
