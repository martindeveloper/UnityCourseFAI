using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInfo : MonoBehaviour
{
    public void Awake()
    {
        if(SceneManager.sceneCount == 1)
        {
            SceneManager.LoadScene("Scenes/BaseScene", LoadSceneMode.Additive);
        }
    }
}
