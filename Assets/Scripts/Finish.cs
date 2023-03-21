using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    UIManager uiManager;
    Drive driver;
    Player player;

    [SerializeField] Rewarded rewardedAd;
    [SerializeField] Interstitial interstitialAd;
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        driver = FindObjectOfType<Drive>();
        player = FindObjectOfType<Player>();       
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            #region LOAD ADS
            rewardedAd.LoadRewardedAd();
            interstitialAd.LoadInterstitialAd();
            #endregion
            GameManager.AddCoin(GameManager.LevelPrize);
            driver.gameObject.SetActive(false);
            player.LockMovement();

            uiManager.UpdateCoinText();
            uiManager.OpenEndScreen();

            LevelManager.IncreaseCurrentLevel();
        }

    }



}
