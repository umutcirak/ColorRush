using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static string coinKey = "coin";

    public static int LevelPrize { get { return 100; } }
    public static int RewardFromAds { get { return 400; } }
         

    public static void AddCoin(int coinToAdd)
    {
        if(!PlayerPrefs.HasKey(nameof(coinKey)))
        {
            PlayerPrefs.SetInt(nameof(coinKey), 0);
        }
        else
        {
            int newCoin = PlayerPrefs.GetInt(nameof(coinKey)) + coinToAdd;
            PlayerPrefs.SetInt(nameof(coinKey), newCoin);
        }
    }


    public static int GetCoin()
    {
        return PlayerPrefs.GetInt(nameof(coinKey));
    }


    public static void EmptyCoin()
    {
        PlayerPrefs.SetInt(nameof(coinKey), 0);
    }


}
