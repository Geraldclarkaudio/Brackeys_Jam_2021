using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f;

    private Vector3 direction;
    private Vector3 velocity;

    private CharacterController _controller;

    [Header("Camera Settings")]
    [SerializeField]
    private float _cameraSensitivity = 2.0f;
    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        CameraRotation();


    }

    void CalculateMovement()
    {
        float vertical = Input.GetAxis("Vertical");

        direction = new Vector3(0, 0, vertical);
        velocity = direction * _speed;
        
        velocity = transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }

    void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");


        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.y += mouseX * _cameraSensitivity;
        transform.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.up);



        //apply mousey to camera roation x (look Up and Down)
        //clamp between 0 and 15
        Vector3 currentCamRot = mainCam.gameObject.transform.localEulerAngles;
        currentCamRot.x -= mouseY * _cameraSensitivity;
        currentCamRot.x = Mathf.Clamp(currentCamRot.x, 0, 26);
        mainCam.gameObject.transform.localRotation = Quaternion.AngleAxis(currentCamRot.x, Vector3.right);
    }

    //Cannon Fire? 

}
