using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Animator animator_settings;
    [SerializeField] GameObject img_cancel_sound;
    [SerializeField] GameObject img_cancel_vibration;
    [SerializeField] GameObject restart_button;
    [SerializeField] [Range(0, 2f)] float waitBeforeReload; 

    bool isSettingsOpen; 

    PrefData preferences;

    private void Awake()
    {
        preferences = FindObjectOfType<PrefData>();
    }


    private void Start()
    {
        isSettingsOpen = false;
        SetupInitial();

    }

    public void OpenRestartButton()
    {
        StartCoroutine(OpenRestartCo());
    }

    public IEnumerator OpenRestartCo()
    {
        yield return new WaitForSeconds(waitBeforeReload);
        restart_button.SetActive(true);
    }
   

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FirstTouch.firstTouch = false;
    }
   

    public void OpenLink(string url)
    {
        Application.OpenURL(url);
    }


    public void SwitchSound()
    {
        if (preferences.GetSound())
        {
            img_cancel_sound.SetActive(true);
            preferences.SetSound(false);
            AudioListener.volume = 0;

        }
        else
        {
            img_cancel_sound.SetActive(false);
            preferences.SetSound(true);
            AudioListener.volume = 1;
        }       
    }


    public void SwitchVibration()
    {
        if (preferences.GetVibration())
        {
            img_cancel_vibration.SetActive(true);
            preferences.SetVibration(false);
        }
        else
        {
            img_cancel_vibration.SetActive(false);
            preferences.SetVibration(true);
        }
        
    }


    public void SwitchSettingsVisibility()
    {
        if(isSettingsOpen)
        {
            animator_settings.SetTrigger("slide_out");

        }
        else
        {
            animator_settings.SetTrigger("slide_in");
        }

        isSettingsOpen = !isSettingsOpen;
    }


    void SetupInitial()
    {
        preferences.SetSound(!preferences.GetSound());
        preferences.SetVibration(!preferences.GetVibration());
        SwitchSound();
        SwitchVibration();     

    }


}
