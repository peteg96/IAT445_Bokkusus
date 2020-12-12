using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class changescene : MonoBehaviour
{
    public string scene_name;
    public void Scene1changscene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
    
}