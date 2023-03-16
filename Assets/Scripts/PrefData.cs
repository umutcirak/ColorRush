using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefData : MonoBehaviour
{
    private string soundKey = "IsSoundOn";
    private string vibrationKey = "IsSoundOn";
        

    public void SetSound(bool status)
    {
        if (status)
            PlayerPrefs.SetInt(nameof(soundKey), 1);
        else
            PlayerPrefs.SetInt(nameof(soundKey), 0);
    }

    public bool GetSound()
    {
        int status = -1;
        if (PlayerPrefs.HasKey(nameof(soundKey)))
            status = PlayerPrefs.GetInt(nameof(soundKey));

        switch(status)
        {
            case 0:
                return false;
            case 1:
                return true;    

            default:
                Debug.Log("Sound not assigned!");
                break;
        }
        return true;
    }

    public void SetVibration(bool status)
    {
        if (status)
            PlayerPrefs.SetInt(nameof(vibrationKey), 1);
        else
            PlayerPrefs.SetInt(nameof(vibrationKey), 0);
    }

    public bool GetVibration()
    {
        int status = -1;
        if (PlayerPrefs.HasKey(nameof(vibrationKey)))
            status = PlayerPrefs.GetInt(nameof(vibrationKey));

        switch (status)
        {
            case 0:
                return false;
            case 1:
                return true;
            default:
                Debug.Log("Vibration not assigned!");
                break;
        }
        return true;
    }




}
