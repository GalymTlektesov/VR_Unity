using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGesture : MonoBehaviour
{
    public bool isFacingDown = false;
    public bool isMovingDown = false;
    private float sweepRate = 100.0f;
    private float previosCameraAngle;

    void Start()
    {
        previosCameraAngle = CameraAngleFromGround();
    }
    void Update()
    {
        isFacingDown = DetectFacingDown();
        isMovingDown = DetectMovingDown();
    }

    private bool DetectFacingDown()
    {
        return (CameraAngleFromGround() < 60);
    }

    private float CameraAngleFromGround()
    {
        return Vector3.Angle(Vector3.down, Camera.main.transform.rotation * Vector3.forward);
    }

    private bool DetectMovingDown()
    {
        float angle = CameraAngleFromGround();
        float deltaAngle = previosCameraAngle - angle;
        float rate = deltaAngle / Time.deltaTime;
        previosCameraAngle = angle;
        return (rate >= sweepRate);
    }
}
