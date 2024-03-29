using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    [SerializeField] [Range(1f,100f)] float driveSpeed;


    private bool driveActive = false;

    Player player;
    Camera mainCamera;
    RestrictBounds restrictBounds;


    private void Awake()
    {
        player = FindObjectOfType<Player>();
        restrictBounds = player.GetComponentInChildren<RestrictBounds>();
        mainCamera = Camera.main;
    }


    void Update()
    {
        StartDrive();
        DriveObjects();
    }    

    void DriveObjects()
    {
        if(!driveActive) { return; }

        float increase = driveSpeed * Time.deltaTime;

        player.transform.position += new Vector3(0f, 0f, increase);
        mainCamera.transform.position += new Vector3(0f, 0f, increase);
        restrictBounds.bound_backward += increase;
        restrictBounds.bound_forward += increase;

    }



    private void StartDrive()
    {
        if (driveActive) { return; }
        if (FirstTouch.firstTouch)
        {
            driveActive = true;
        }
    }



}
