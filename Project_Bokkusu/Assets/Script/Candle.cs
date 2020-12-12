using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : MonoBehaviour
{

    public GameObject light, GUI;
    public GameObject fire;
    public AudioClip lightUp, lightOff;
    AudioSource audio;
    float timer;
    bool state = false, sswitch = true;
    private void Start()
    {
        audio = this.GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {

            state = true;
            GUI.SetActive(true);
            //switch the state 
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            state = false;
            GUI.SetActive(false);
        }
    }
    private void Update()
    {
        if (state && Input.GetKeyDown(KeyCode.E))
        {
            if (sswitch)
            {
                audio.PlayOneShot(lightOff, 0.3f);
                StartCoroutine(Coroutine());
                
            }
            else
            {
                audio.PlayOneShot(lightUp, 0.3f);
                StartCoroutine(Coroutine());
            }
        }

        
    }


    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(0.5f);
        if (sswitch)
        {
            yield return new WaitForSeconds(0.5f);
            sswitch = false;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            sswitch = true;
        }
        light.SetActive(sswitch);
        fire.SetActive(sswitch);

    }
}
