using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEntity : MonoBehaviour
{
    public int GetMaximumApples()
    {
        return Random.Range(10, 20);
    }
}
