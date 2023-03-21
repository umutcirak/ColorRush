using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingScene : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI loading_text;
   
    void Start()
    {
        #region REMOVE IT LATER
        LevelManager.SetLevel(1);
        Debug.Log("Level Index " + LevelManager.GetLevel());
        #endregion
        StartCoroutine(StartLoadingAnim());
        LevelManager.LoadSceneAsync();
         
    }

    private IEnumerator StartLoadingAnim()
    {
        while (true)
        {
            loading_text.text = "LOADING";
            yield return new WaitForSeconds(0.5f);
            loading_text.text = "LOADING.";
            yield return new WaitForSeconds(0.5f);
            loading_text.text = "LOADING..";
            yield return new WaitForSeconds(0.5f);
            loading_text.text = "LOADING...";
            yield return new WaitForSeconds(0.5f);

        }
    }


}
