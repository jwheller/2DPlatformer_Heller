﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform;
    private Vector3 smoothPos;
    private float smoothSpeed = 0.5f;

    public GameObject CameraLeftBorder;
    public GameObject CameraRightBorder;

    private float cameraHalfWidth;

    // Start is called before the first frame update
    void Start()
    {
        cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float borderLeft = CameraLeftBorder.transform.position.x + cameraHalfWidth;
        float borderRight = CameraRightBorder.transform.position.x - cameraHalfWidth;

        smoothPos = Vector3.Lerp(this.transform.position,
            new Vector3(Mathf.Clamp(followTransform.position.x, borderLeft, borderRight),
            this.transform.position.y,
            this.transform.position.z), smoothSpeed);

        this.transform.position = smoothPos;
    }
}
