using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FirstTouch : MonoBehaviour
{
    [SerializeField] GameObject[] elements;

    public static bool firstTouch;
   
    private void Update()
    {
        CheckFirstTouch();      
    }

    public void DeactivateElements()
    {               
        foreach (GameObject element in elements)
        {
            element.SetActive(false);
        }
    }

    void CheckFirstTouch()
    {
        if (firstTouch)
            return;
        else if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {           

            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                Debug.Log("Touching a UI element");
                firstTouch = true;
                DeactivateElements();
            }
            


        }
      
    }


}
