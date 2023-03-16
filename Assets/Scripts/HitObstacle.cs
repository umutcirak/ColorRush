using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObstacle : MonoBehaviour
{
    [SerializeField] GameObject ballItem;
    [SerializeField] GameObject[] fractureItems;

    Player player;
    UIManager uiManager;
    CameraShake cameraShaker;
    Drive driver;
    Shock shockEffect;

    private bool hitOnce;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        driver = FindObjectOfType<Drive>();
        cameraShaker = FindObjectOfType<CameraShake>();
        shockEffect = FindObjectOfType<Shock>();
        uiManager = FindObjectOfType<UIManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (!hitOnce)
                hitOnce = true;
            else
                return;

            driver.gameObject.SetActive(false);
            player.LockMovement();
            cameraShaker.ShakeCamera();
            shockEffect.DoShock();
            uiManager.OpenRestartButton();
            

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
