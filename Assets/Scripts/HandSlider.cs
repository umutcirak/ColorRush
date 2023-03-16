using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSlider : MonoBehaviour
{   
    [SerializeField] Vector3 leftBound;
    [SerializeField] Vector3 rightBound;
    [SerializeField] float speed;

    private bool isRight;
       
        
    void Start()
    {
        transform.rotation = Camera.main.transform.rotation;
        leftBound.y = transform.position.y;
        rightBound.y = transform.position.y;
        leftBound.z = transform.position.z;
        rightBound.z = transform.position.z;

        isRight = true;
    }

   
    void FixedUpdate()
    {
        StartCoroutine(SlideCo());       
    }

    

    private IEnumerator SlideCo()
    {
        if(isRight)
            transform.position = Vector3.MoveTowards(transform.position, rightBound, speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, leftBound, speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - rightBound.x) < 0.1f)
            isRight = false;
        else if (Mathf.Abs(transform.position.x - leftBound.x) < 0.1f)
            isRight = true;

            yield return null;        
    }   

    

}
