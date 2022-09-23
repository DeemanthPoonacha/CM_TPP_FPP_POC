using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamController : MonoBehaviour
{
    public PlayerCam playerCam;

    public CinemachineVirtualCamera FPP_Cam;
    public CinemachineVirtualCamera TPP_Cam;

    Camera mainCamera;
    CinemachineVirtualCamera _activeCamera;

    int cameraPriorityFactor=100;

    private bool prevVal=false;

    private void Awake()
    {
        mainCamera=Camera.main;
    }

    private void Start()
    {
        ChangeCamera();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            ChangeCamera();
        }
    }

    private void ChangeCamera()
    {
        if(_activeCamera==FPP_Cam)
        {
            FPP_Cam.Priority -= cameraPriorityFactor;
            TPP_Cam.Priority += cameraPriorityFactor;
            _activeCamera = TPP_Cam;
            mainCamera.cullingMask |= (1 << LayerMask.NameToLayer("Character"));
            playerCam.TPP=true;
        }
        else if(_activeCamera==TPP_Cam)
        {
            TPP_Cam.Priority -= cameraPriorityFactor;
            FPP_Cam.Priority += cameraPriorityFactor;
            _activeCamera = FPP_Cam;
            mainCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("Character"));
            playerCam.TPP=false;
        }
        else
        {
            TPP_Cam.Priority += cameraPriorityFactor;
            _activeCamera = TPP_Cam;
            playerCam.TPP=true;
        }
        playerCam.RotateCamera();

    }
}
