using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEntity : MonoBehaviour
{
    public GameObject ApplePrefab;

    [Range(0, 10)]
    public int TimeOut = 5;

    private bool CanSpawnApples = true;

    public int GetMaximumApples()
    {
        return Random.Range(10, 20);
    }

    public bool SpawnApples(int number)
    {
        if(CanSpawnApples)
        {
            Collider collider = GetComponent<Collider>();

            for(int i = 0; i < number; i++)
            {
                Instantiate(ApplePrefab, MakeRandomPositionInBounds(collider.bounds), Quaternion.identity);
            }

            CanSpawnApples = false;

            StartCoroutine(ResetSpawning());

            return true;
        }

        return false;
    }

    public Vector3 MakeRandomPositionInBounds(Bounds bounds)
    {
        Vector3 position = new Vector3(
            Random.Range(bounds.extents.x, -bounds.extents.x),
            Random.Range(bounds.extents.y, -bounds.extents.y),
            Random.Range(bounds.extents.z, -bounds.extents.z)
            );

        return bounds.center - position;
    }

    private IEnumerator ResetSpawning()
    {
        yield return new WaitForSeconds(TimeOut);

        CanSpawnApples = true;
    }
}
