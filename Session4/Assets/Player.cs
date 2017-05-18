using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tags
{
    public const string TreeEntity = "TreeEntity";
    public const string AppleEntity = "AppleEntity";
}

public class Player : MonoBehaviour
{
    public Rigidbody ColliderRigidbody;
    public Joint HandJoint;

    public void Start()
    {
        HandJoint = GetComponent<Joint>();
        HandJoint.enablePreprocessing = false;
    }

    public void FixedUpdate()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            RaycastHit hit;

            bool isHit = Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5.0f);

            if(isHit)
            {
                //Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red, 5.0f);

                if (hit.collider.CompareTag(Tags.TreeEntity))
                {
                    TreeEntity tree = hit.collider.GetComponent<TreeEntity>();

                    Debug.LogFormat("Maximum Apples {0}", tree.GetMaximumApples());

                    bool areApplesSpawned = tree.SpawnApples(5);

                    Debug.LogFormat("Spawning apples {0}", areApplesSpawned);
                }

                if(hit.collider.CompareTag(Tags.AppleEntity))
                {
                    //hit.collider.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 1000);
                    Rigidbody appleRigidbody = hit.collider.GetComponent<Rigidbody>();

                    HandJoint.connectedBody = appleRigidbody;
                }
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("Entered to trigger named {0}", other.name);
    }
}
