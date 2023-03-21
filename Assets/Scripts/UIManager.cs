using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] Animator animator_settings;
    [SerializeField] GameObject img_cancel_sound;
    [SerializeField] GameObject img_cancel_vibration;
    [SerializeField] GameObject restart_button;
    [SerializeField] [Range(0, 2f)] float waitBeforeReload;
    

    [SerializeField] TextMeshProUGUI text_coin;
    [SerializeField] Transform endPos;
    [SerializeField] Image progressBar;

    [Header("End Screen Objects")]
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject endBg;
    [SerializeField] GameObject completed_img;
    [SerializeField] GameObject prize_bg;
    [SerializeField] GameObject prize;
    [SerializeField] GameObject claim_button;
    [SerializeField] GameObject nothanks_button;

    [Header("After Reward")]
    [SerializeField] GameObject reward;
    [SerializeField] TextMeshProUGUI reward_text;
    [SerializeField] GameObject nextLevelButton;

    bool isSettingsOpen; 

    PrefData preferences;
    Transform playerPos;
    float start_pos_gap;

    private void Awake()
    {
        preferences = FindObjectOfType<PrefData>();
        playerPos = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    private void Start()
    {
        isSettingsOpen = false;
        SetupInitial();
        start_pos_gap = playerPos.position.z;
    }

    void LateUpdate()
    {
        FillProgressBar();
    }
   

    private void FillProgressBar()
    {
        float fill = (playerPos.position.z - start_pos_gap) / (endPos.position.z - start_pos_gap);
        progressBar.fillAmount = fill;       
    }

    public void OpenEndScreen()
    {
        StartCoroutine(OpenEndScreenCo());
    }


    private IEnumerator OpenEndScreenCo()
    {      

        endScreen.SetActive(true);
        endBg.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        completed_img.SetActive(true);
        yield return new WaitForSeconds(0.35f);
        prize_bg.SetActive(true);
        prize.SetActive(true);
        yield return new WaitForSeconds(0.35f);        
        claim_button.SetActive(true);
        nothanks_button.SetActive(true);       
        
    }


    public void UpdateCoinText()
    {
        text_coin.text = GameManager.GetCoin().ToString();
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
   
    public void OpenNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1 );
        FirstTouch.firstTouch = false;
    } 

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FirstTouch.firstTouch = false;
    }

    public void RunRewardAnim(int prize)
    {
        StartCoroutine(RewardAnimateCo(prize));
    }

    private IEnumerator RewardAnimateCo(int prize)
    {
        float speed = 200f;
        float current = 0f;

        while (Mathf.Abs(current - prize) > 0.25f)
        {
            current = Mathf.MoveTowards(current, prize, speed * Time.deltaTime);
            reward_text.text = "+ " + (int)current;
            yield return new WaitForEndOfFrame();
        }

        reward_text.text = "+ " + prize;
        nextLevelButton.SetActive(true);
    }


    public void AfterReward()
    {
        //[Header("After Reward")]
        //[SerializeField] GameObject reward;
        // [SerializeField] TextMeshProUGUI reward_text;
        // [SerializeField] GameObject nextLevelButton;

        claim_button.SetActive(false);      
        nothanks_button.SetActive(false);

        reward.SetActive(true);
        reward_text.gameObject.SetActive(true);
        RunRewardAnim(GameManager.RewardFromAds);    
        

    }

    public void OpenLink(string url)
    {
        Application.OpenURL(url);
    }

    public void SetCoin()
    {
        GameManager.GetCoin();
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
        UpdateCoinText();

    }


}
