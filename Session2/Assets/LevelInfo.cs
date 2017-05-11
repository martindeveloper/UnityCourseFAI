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

    public void Start()
    {
        MovePlayerToSpawn();
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
