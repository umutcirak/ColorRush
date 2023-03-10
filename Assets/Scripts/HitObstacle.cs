using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObstacle : MonoBehaviour
{
    [SerializeField] GameObject ballItem;
    [SerializeField] GameObject[] fractureItems;

    CameraShake cameraShaker;
    Drive driver;
    Shock shockEffect;

    private void Awake()
    {
        driver = FindObjectOfType<Drive>();
        cameraShaker = FindObjectOfType<CameraShake>();
        shockEffect = FindObjectOfType<Shock>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            driver.gameObject.SetActive(false);

            cameraShaker.ShakeCamera();
            shockEffect.DoShock();

            ballItem.SetActive(false);

            foreach (var fracure in fractureItems)
            {
                fracure.GetComponent<SphereCollider>().enabled = true;
            }

            foreach (var fracure in fractureItems)
            {
                fracure.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }




}
