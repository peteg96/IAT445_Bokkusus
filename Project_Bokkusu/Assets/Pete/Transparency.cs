using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    public GameObject girl;
    float  t;

    float x;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        for (int i = 0; i < 4; i++)
        {
            var material = girl.transform.GetChild(i);
            material.GetComponent<Renderer>().enabled = false;
        }
        x = 2.0f;
        girl.GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        x-=Time.deltaTime;
        if(girl.GetComponent<AudioSource>().isPlaying == false) girl.GetComponent<AudioSource>().Play();
        if (x < 0)
        {
            for (int i = 0; i < 4; i++)
            {
                var material = girl.transform.GetChild(i);
                material.GetComponent<Renderer>().enabled = true;
            }
            t += 0.0006f;
            if (t >= 0.5f)
            {
                t = 0.5f;
                girl.GetComponent<AudioSource>().Stop();
            }
            for (int i = 0; i < 4; i++)
            {
                var material = girl.transform.GetChild(i);
                ChangeAlpha(material.GetComponent<Renderer>().material, t);
            }
        }
        //ChangeAlpha(girl.GetComponent<Renderer>().material, t);
        
        
    }
    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);

    }
}
