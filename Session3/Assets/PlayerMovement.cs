using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range(5.0f, 50.0f)]
    public float Speed = 10.0f;

    public void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
        float horizontalInput = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;

        transform.Translate(horizontalInput, 0, verticalInput);
    }
}
