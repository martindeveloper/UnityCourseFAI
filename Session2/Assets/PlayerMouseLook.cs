using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseLook : MonoBehaviour {
    public enum RotationAxes { MouseX = 0, MouseY }

    public RotationAxes TargetAxis = RotationAxes.MouseX;

    public Vector2 Sensitivity = new Vector2(15.0f, 15.0f);

    public Vector4 MinimumLookRotation = new Vector4(-360.0f, 360.0f, -60.0f, 60.0f);

    private Quaternion OriginalRotation;

    private Vector2 LookRotation = new Vector2(0.0f, 0.0f);

    public void Start()
    {
        OriginalRotation = transform.localRotation;
    }

    public void FixedUpdate()
    {
        if (TargetAxis == RotationAxes.MouseX)
        {
            LookRotation.x += Input.GetAxis("Mouse X") * Sensitivity.x;
            LookRotation.x = ClampAngle(LookRotation.x, MinimumLookRotation.x, MinimumLookRotation.y);

            Quaternion xQuaternion = Quaternion.AngleAxis(LookRotation.x, Vector3.up);
            transform.localRotation = OriginalRotation * xQuaternion;
        }
        else
        {
            LookRotation.y += Input.GetAxis("Mouse Y") * Sensitivity.y;
            LookRotation.y = ClampAngle(LookRotation.y, MinimumLookRotation.z, MinimumLookRotation.w);

            Quaternion yQuaternion = Quaternion.AngleAxis(LookRotation.y, Vector3.left);
            transform.localRotation = OriginalRotation * yQuaternion;
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f)
        {
            angle += 360f;
        }

        if (angle > 360f)
        {
            angle -= 360f;
        }

        return Mathf.Clamp(angle, min, max);
    }
}
