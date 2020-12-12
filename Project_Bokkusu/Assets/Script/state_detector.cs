using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state_detector : MonoBehaviour
{
    public bool isholding;
    public GameObject seal, sealcage, lightgame;
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        isholding = false;
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (num == 6)
        {
            //seal.SetActive(false);
        }
        if (lightgame.GetComponent<game_light>().state){
            //sealL.SetActive(false);
            }
        if (num == 6 && lightgame.GetComponent<game_light>().state) sealcage.SetActive(false);
    }


}
