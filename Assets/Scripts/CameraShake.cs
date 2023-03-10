using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float duration;    
    [SerializeField] float radius;

    Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void ShakeCamera()
    {
        StartCoroutine(ShakeCameraCo());
    }

    private IEnumerator ShakeCameraCo()
    {
        Vector3 initialPos = mainCamera.transform.position;

        float timeElapsed = 0f;

        while(timeElapsed < duration)
        {
            float jump = Random.Range(-radius, radius);

            mainCamera.transform.position += new Vector3(jump, jump, jump) * Time.deltaTime;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = initialPos;
        yield return null;

    }








}
