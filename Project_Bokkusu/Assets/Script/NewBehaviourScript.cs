using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public void quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
