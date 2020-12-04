using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomCheck : MonoBehaviour
{
    public bool inRoomCheck;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            inRoomCheck = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRoomCheck = false;
        }
    }
}
