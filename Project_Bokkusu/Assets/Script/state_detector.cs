﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class state_detector : MonoBehaviour
{
    public bool isholding;
    public GameObject seal;
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
        print(num);
        if (num == 6) seal.SetActive(false);

    }


}
