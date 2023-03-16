using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RestrictBounds))]
public class Player : MonoBehaviour
{
    private Touch touch;
    private Rigidbody rgbd;

    [SerializeField] [Range(0f, 100f)] float speed;

    public bool lockPlayer;

    private void Awake()
    {
        rgbd = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovePlayer();
    }


    void MovePlayer()
    {
        if(FirstTouch.firstTouch && !lockPlayer && Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);            

            if (touch.phase == TouchPhase.Moved)
            {
                rgbd.velocity = new Vector3(touch.deltaPosition.x * speed * Time.deltaTime,
                                                0f,
                                            touch.deltaPosition.y * speed * Time.deltaTime);
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                rgbd.velocity = Vector3.zero;
            }  
            

        }

    }

    public void LockMovement()
    {
        rgbd.velocity = Vector3.zero;
        lockPlayer = true;
    }

   



}
