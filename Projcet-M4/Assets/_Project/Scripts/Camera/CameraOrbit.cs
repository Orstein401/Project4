using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraOrbit : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private GameObject target;

    [Header("PositionCam")]
    [SerializeField] private Vector3 offSet;
    private Vector3 desirePos;
    private Quaternion rotation;

    [Header("Clamp Parametres")]
    [SerializeField] private float bottomClamp;
    [SerializeField] private float upClamp;

    [Header("InputMouse")]
    private float yaw;
    private float pitch;

    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }
    private void Update()
    {
        if (target != null)
        {
            GetInput();
            CalculatePos();
        }
    }
    private void LateUpdate()
    {
        if (target != null)
        {
            transform.SetPositionAndRotation(desirePos, rotation);
        }
    }
    private void GetInput()
    {
        yaw += Input.GetAxis("Mouse X");
        pitch -= Input.GetAxis("Mouse Y");

    }

    private void CalculatePos()
    {
        pitch = Mathf.Clamp(pitch, bottomClamp, upClamp);

        rotation = Quaternion.Euler(pitch, yaw, 0f);

        desirePos = target.transform.position + rotation * offSet;
    }
}
