using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class LevelManager : MonoBehaviour
{
    private static string levelIndexKey = "LevelIndex";
           

    public static int GetLevel()
    {
        if (!PlayerPrefs.HasKey(nameof(levelIndexKey)))
        {
            PlayerPrefs.SetInt(nameof(levelIndexKey), 1);
            return 1;
        }
        else
        {
            return PlayerPrefs.GetInt(nameof(levelIndexKey));
        }
    }

    public static void IncreaseCurrentLevel()
    {
        if (PlayerPrefs.HasKey(nameof(levelIndexKey)))
        {
            int nextLevel = PlayerPrefs.GetInt(nameof(levelIndexKey)) + 1;
            if(nextLevel != SceneManager.sceneCount)
            {
                PlayerPrefs.SetInt(nameof(levelIndexKey), nextLevel);
            }
        }           
    }

    public static void LoadSceneAsync()
    {
        if (GetLevel() != SceneManager.sceneCountInBuildSettings) 
        {
            SceneManager.LoadSceneAsync(GetLevel());
        }        
    }
    public static void SetLevel(int level)
    {
        PlayerPrefs.SetInt(nameof(levelIndexKey), level);
    }
    


}
