using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fog_off : MonoBehaviour
{
    public Material skb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player" )
        {
            RenderSettings.fog = false;
            RenderSettings.skybox = skb;
        }


    }
}
