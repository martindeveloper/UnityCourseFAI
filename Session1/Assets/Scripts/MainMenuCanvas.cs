using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour
{
    public UnityEngine.UI.Button StartButton;

    public void Start()
    {
        StartButton.onClick.AddListener(OnStartButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        SceneManager.LoadScene("Scenes/Levels/Level1", LoadSceneMode.Additive);

        Debug.Log("Start button cliked!");
    }
}
