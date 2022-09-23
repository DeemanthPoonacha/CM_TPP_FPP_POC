using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float xSensitivity;
    public float ySensitivity;
    public float clampVerticalAngle=90;

    public float smoothAlignTime=4;

    public Transform Player;
    public bool TPP=true;

    [Range(0.0f, 0.3f)]
    public float RotationSmoothTime = 0.12f;

    float xRotation;
    float yRotation;

    int dt=500;
    float _rotationVelocity;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        // Cursor.visible=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {   
            RotateCamera();
            AlignPlayerToCam();
        }
        else if(TPP && dt >= 500 && transform.rotation != Player.rotation){
            AlignCam();
        }
        else if(TPP){
            dt++;
            AlignPlayerToCam();
        }
        // Debug.Log("ddd "+ Player.rotation);
    }

    public void RotateCamera()
    {
        float mouseX=Input.GetAxisRaw("Mouse X")*Time.deltaTime*xSensitivity;
        float mouseY=Input.GetAxisRaw("Mouse Y")*Time.deltaTime*ySensitivity;

        yRotation+=mouseX;
        xRotation-=mouseY;

        xRotation=Mathf.Clamp(xRotation, -clampVerticalAngle, clampVerticalAngle);
        transform.rotation = Quaternion.Euler(xRotation,yRotation,0);

        if(TPP)
        {
            dt=0;
        }
        else
        {
            Player.rotation = Quaternion.Euler(0,yRotation,0);
        }
    }

    public void AlignCam()
    {
        // float angle = Mathf.LerpAngle(transform.rotation.y, 0, 0f);
        // transform.eulerAngles = new Vector3(0, angle, 0);
        transform.rotation=Quaternion.Slerp(transform.rotation, Player.rotation,smoothAlignTime*Time.deltaTime);
        yRotation=Player.eulerAngles.y;
        xRotation=Player.eulerAngles.x;
    }

    public void AlignPlayerToCam()
    {   
        if(Input.GetAxis("Horizontal")+Input.GetAxis("Vertical")!=0){
            // Player.rotation = Quaternion.Euler(0,yRotation,0);
            transform.rotation=Quaternion.Euler(0,yRotation,0);//Quaternion.Slerp(Quaternion.Euler(0,yRotation,0), Player.rotation,smoothAlignTime*Time.deltaTime);
            dt=0;

            
            float _targetRotation = Camera.main.transform.eulerAngles.y;
            float rotation = Mathf.SmoothDampAngle(Player.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                RotationSmoothTime);

            // rotate to face input direction relative to camera position
            Player.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        }
    }
}
