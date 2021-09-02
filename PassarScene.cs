using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PassarScene : MonoBehaviour
{
    public void Scene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
