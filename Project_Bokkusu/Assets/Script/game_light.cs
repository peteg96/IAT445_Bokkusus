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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (light1.active == false && light2.active && light3.active && light4.active && light5.active == false
               && light6.active == false && light7.active == false && light8.active && light9.active)
        {
            print(1);
        }
        
       if (light1.activeSelf ==false && light2.activeSelf && light3.activeSelf && light4.activeSelf && light5.activeSelf == false
                && light6.activeSelf == false && light7.activeSelf == false && light8.activeSelf && light9.activeSelf)
        {
            print(1);
        }
        */
        
        if ((!light1.activeSelf && light2.activeSelf && light3.activeSelf && light4.activeSelf && !light5.activeSelf 
                 && !light6.activeSelf  && !light7.activeSelf  && light8.activeSelf && light9.activeSelf)==true)
        {
            print(1);
        }
        /*
        print(!light1.activeSelf && light2.activeSelf && light3.activeSelf && light4.activeSelf && !light5.activeSelf
                 && !light6.activeSelf && !light7.activeSelf && light8.activeSelf && light9.activeSelf);
        */

    }
}
