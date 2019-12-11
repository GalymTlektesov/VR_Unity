using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadGesture : MonoBehaviour
{
    public bool isFacingDown = false;
    public bool isFacingUp = false;
    private float sweepRate = 100.0f;
    public bool isMovingDown = false;
    public bool isMovingUp = false;

    private float previosCameraAngleUp;
    private float previosCameraAngleDown;

    void Start()
    {
        previosCameraAngleUp = CameraAngleFromSky();
        previosCameraAngleDown = CameraAngleFromGround();
    }
    void Update()
    {
        isFacingDown = DetectFacingDown();
        isFacingUp = DetectFacingUp();
        isMovingDown = DetectMovingDown();
        isMovingUp = DetectMovingUp();
    }

    private bool DetectFacingDown()
    {
        return (CameraAngleFromGround() < 60);
    }
    private bool DetectFacingUp()
    {
        return (CameraAngleFromSky() < 60);
    }

    private float CameraAngleFromSky()
    {
        return Vector3.Angle(Vector3.up, Camera.main.transform.localRotation * Vector3.forward);
    }

    private float CameraAngleFromGround()
    {
        return Vector3.Angle(Vector3.down, Camera.main.transform.localRotation * Vector3.forward);
    }

    private bool DetectMovingUp()
    {
        float angle = CameraAngleFromSky();
        float deltaAngle = previosCameraAngleUp - angle;
        float rate = deltaAngle / Time.deltaTime;
        previosCameraAngleUp = angle;
        return (rate >= sweepRate);
    }

    private bool DetectMovingDown()
    {
        float angle = CameraAngleFromGround();
        float deltaAngle = previosCameraAngleDown - angle;
        float rate = deltaAngle / Time.deltaTime;
        previosCameraAngleDown = angle;
        return (rate >= sweepRate);
    }
}
