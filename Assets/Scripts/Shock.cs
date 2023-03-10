using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shock : MonoBehaviour
{
    [SerializeField] Image whiteImage;
    [SerializeField] float duration;

    public void DoShock()
    {
        StartCoroutine(ShockCo());
    }

    public IEnumerator ShockCo()
    {
        float transparency = 0f;
        float timeElapsed = 0f;

        whiteImage.gameObject.SetActive(true);

        while(whiteImage.color.a < 0.99f)
        {
            transparency = timeElapsed / duration;
            whiteImage.color = new Color(whiteImage.color.r, whiteImage.color.g, whiteImage.color.b, transparency);

            timeElapsed += Time.deltaTime;
            yield return null;
        }
       
        float timeLeft = duration;

        while (whiteImage.color.a > 0.01f)
        {
            transparency = timeLeft / duration;
            whiteImage.color = new Color(whiteImage.color.r, whiteImage.color.g, whiteImage.color.b, transparency);

            timeLeft -= Time.deltaTime;
            yield return null;
        }


        whiteImage.gameObject.SetActive(false);
    }




}
