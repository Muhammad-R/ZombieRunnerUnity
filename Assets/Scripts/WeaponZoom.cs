using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private RigidbodyFirstPersonController fpsController;

    private bool isZoomedIn = false;
    
    // Start is called before the first frame update
    void Start()
    {
        fpsController = GetComponentInParent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isZoomedIn)
        {
            ZoomIn();
        } else if (Input.GetMouseButtonDown(1) && isZoomedIn)
        {
            ZoomOut();
        }
    }

    public void ZoomOut()
    {
        isZoomedIn = false;
        mainCamera.fieldOfView = 60f;
        fpsController.mouseLook.XSensitivity = 2f;
        fpsController.mouseLook.YSensitivity = 2f;
    }

    private void ZoomIn()
    {
        isZoomedIn = true;
        mainCamera.fieldOfView = 20f;
        fpsController.mouseLook.XSensitivity = 0.6f;
        fpsController.mouseLook.YSensitivity = 0.6f;
    }

    private void OnDisable()
    {
        ZoomOut();
    }
}
