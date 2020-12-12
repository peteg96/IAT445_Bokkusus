using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    public GameObject girl, box, seal, sprite, ui;
    float  t;
    public bool state = false;
    float x;
    bool inrange;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        for (int i = 0; i < 4; i++)
        {
            var material = girl.transform.GetChild(i);
            material.GetComponent<Renderer>().enabled = false;
        }
        x = 1.5f;
        girl.GetComponent<AudioSource>().Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (state)
        {
            
            sprite.SetActive(false);
            seal.GetComponent<Animator>().SetBool("boxOpen", true);
            box.GetComponent<Animator>().SetBool("open", true);
            x -= Time.deltaTime;
            
            if (x < 0)
            {
                if (girl.GetComponent<AudioSource>().isPlaying == false) girl.GetComponent<AudioSource>().Play();
                for (int i = 0; i < 4; i++)
                {
                    var material = girl.transform.GetChild(i);
                    material.GetComponent<Renderer>().enabled = true;
                }
                t += 0.0005f;

                if (t >= 0.2f)//fade music
                {
                    //print(girl.GetComponent<AudioSource>().volume);
                    girl.GetComponent<AudioSource>().volume -= 0.001f;
                }

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

            if (t == 0.5)
            {

                //sprite.SetActive(true);
                //sprite.GetComponent<Animator>().SetInteger("state", 5);
            }
        }


        if (inrange && state == false)
        {
            ui.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E)){
                state = true;
                ui.SetActive(false);
            }

        }
    }
    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") inrange = true;
    }
}
