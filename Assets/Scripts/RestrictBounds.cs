using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictBounds : MonoBehaviour
{
    Player player;
    Camera mainCamera;

    [Header("Bounds")]
    [SerializeField] float bound_left;
    [SerializeField] float bound_right;
    public float bound_backward;
    public float bound_forward;
   


    private void LateUpdate()
    {
        RestrictPos();
    }

    void RestrictPos()
    {
        float pos_x = Mathf.Clamp(transform.position.x, bound_left, bound_right);
        float pos_z = Mathf.Clamp(transform.position.z, bound_backward, bound_forward);

        transform.position = new Vector3(pos_x, transform.position.y, pos_z);
    }
    

}
