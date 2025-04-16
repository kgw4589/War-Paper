using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject player;

    private CameraController _cameraController;

    protected override void Init()
    {
        player = GameObject.FindWithTag("Player");
        _cameraController = GameObject.FindWithTag("MainCamera").GetComponentInParent<CameraController>();
    }

    public void ShakeCamera()
    {
        _cameraController.ShakeCamera();
    }
}
