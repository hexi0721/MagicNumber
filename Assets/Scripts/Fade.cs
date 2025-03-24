using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fade : MonoBehaviour
{
    
    [SerializeField] bool fadeIn , fadeOut;
    float alpha;

    private void Start()
    {
        alpha = GetComponent<TextMeshProUGUI>().color.a;

        if(alpha >= 0f)
        {
            fadeIn = true;
            fadeOut = false;
        }


    }

    private void Update()
    {
        /*
        alpha = GetComponent<TextMeshProUGUI>().color.a;
        Debug.Log(alpha);
        */
        if (fadeIn)
        {
            alpha -= Time.deltaTime;

            Color color = GetComponent<TextMeshProUGUI>().color;
            color.a = alpha;
            GetComponent<TextMeshProUGUI>().color = color;
            if (alpha <= 0)
            {
                alpha = 0f;
                fadeIn = false;
                FadeOut();
            }
        }

        if (fadeOut)
        {
            alpha += Time.deltaTime;

            Color color = GetComponent<TextMeshProUGUI>().color;
            color.a = alpha;
            GetComponent<TextMeshProUGUI>().color = color;
            if (alpha >= 1)
            {
                alpha = 1f;
                fadeOut = false;
                FadeIn();
            }
        }
    }

    private void FadeIn()
    {
        fadeIn = true;
    }
    private void FadeOut()
    {
        fadeOut = true;
    }






}
