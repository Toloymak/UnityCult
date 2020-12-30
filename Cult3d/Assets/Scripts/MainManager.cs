using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private CameraControlService _cameraControlService;
    
    // Start is called before the first frame update
    void Start()
    {
        _cameraControlService = new CameraControlService();
    }

    // Update is called once per frame
    void Update()
    {
        _cameraControlService.MoveCamera();
    }
}
