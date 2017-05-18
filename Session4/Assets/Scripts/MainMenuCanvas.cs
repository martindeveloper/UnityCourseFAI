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
        string levelName = "Scenes/Levels/Level1";

        StartCoroutine(LoadLevelByPath(levelName));

        Debug.Log("Start button cliked!");
    }

    private IEnumerator LoadLevelByPath(string path)
    {
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(path, LoadSceneMode.Additive);

        loadingOperation.allowSceneActivation = false;

        while (loadingOperation.progress != 0.9f)
        {
            yield return new WaitForEndOfFrame();
        }

        loadingOperation.allowSceneActivation = true;

        //gameObject.SetActive(false);
    }
}
