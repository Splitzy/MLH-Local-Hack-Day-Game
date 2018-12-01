using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 cameraInitialPos;
    public float shakeMagnitude = 0.05f, shakeTime = 0.5f;
    public Camera mainCamera;

    public void ShakeIt()
    {
        cameraInitialPos = mainCamera.transform.position;
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
    }

    void StartCameraShaking()
    {
        float cameraShakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float cameraShakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        Vector3 cameraIntermediatePos = mainCamera.transform.position;
        cameraIntermediatePos.x = cameraShakingOffsetX;
        cameraIntermediatePos.y = cameraShakingOffsetY;
        mainCamera.transform.position = cameraIntermediatePos;
    }

    void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
        mainCamera.transform.position = cameraInitialPos;
    }

	
}
