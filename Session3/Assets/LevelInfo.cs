using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInfo : MonoBehaviour
{
    private bool IsRunningDirectly = false;

    public void Awake()
    {
        IsRunningDirectly = (SceneManager.sceneCount == 1);

        if (IsRunningDirectly)
        {
            SceneManager.LoadScene("Scenes/BaseScene", LoadSceneMode.Additive);
        }
    }

    public void Start()
    {
        MovePlayerToSpawn();

        if(IsRunningDirectly)
        {
            MainMenuCanvas mainMenu = FindObjectOfType<MainMenuCanvas>();
            mainMenu.gameObject.SetActive(false);
        }
    }

    private void MovePlayerToSpawn()
    {
        Player playerReference = GameObject.FindObjectOfType<Player>();

        GameObject PlayerGameObjectReference = playerReference.gameObject;
        GameObject SpawnGameObject = GameObject.FindGameObjectWithTag("PlayerSpawn");
        Vector3 SpawnLocation = SpawnGameObject.transform.position;

        Debug.Log(PlayerGameObjectReference.transform.position);
        Debug.Log(SpawnLocation);

        PlayerGameObjectReference.transform.position = SpawnLocation;

        playerReference.ColliderRigidbody.isKinematic = false;
    }
}
