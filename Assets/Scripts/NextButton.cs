using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class NextButton : MonoBehaviour
{
    TextMeshProUGUI numberText , wrongMsgText;
    GameObject bottomObj;

    Func<int> GetTotalAnswerFunc;

    [SerializeField] GameObject hintButtonObj;
    Button replayButton;


    public void GetTotalAnswer(int totalAnswer)
    {
        SetGetTotalAnswerFunc(() => totalAnswer);
    }
    
    public void SetGetTotalAnswerFunc(Func<int> GetTotalAnswerFunc)
    {
        this.GetTotalAnswerFunc = GetTotalAnswerFunc;
    }

    public void SetUp(TextMeshProUGUI numberText ,  TextMeshProUGUI wrongMsgText , GameObject bottomObj , Button replayButton)
    {
        this.numberText = numberText;
        this.wrongMsgText = wrongMsgText;
        this.bottomObj = bottomObj;
        this.replayButton = replayButton;
    }



    public void AfterCalcute() 
    {
        int totalAnswer = GetTotalAnswerFunc();

        // 如果不在 1 ~ 63 之間
        if (totalAnswer < 1 || totalAnswer > 63)
        {
            wrongMsgText.gameObject.SetActive(true);
            return;
        }
        
        numberText.gameObject.SetActive(true);
        StartCoroutine(RandomAnimate(totalAnswer));

        // 關掉一些按鈕，只開啟Replaybutton
        Image nextButtonImgae = GetComponent<Image>();
        nextButtonImgae.raycastTarget = false;
        Color color = nextButtonImgae.color;
        color.a = 0f;
        nextButtonImgae.color = color;

        int BottomChildCount = bottomObj.transform.childCount;
        for (int i = 0; i < BottomChildCount; i++)
        {
            bottomObj.transform.GetChild(i).gameObject.SetActive(false);
        }
        hintButtonObj.SetActive(false);
    }

    public IEnumerator RandomAnimate(int totalAnswer)
    {
        float elapsedTime = 0f;
        float duration = 2f;

        while (elapsedTime < duration)
        {
            int number = UnityEngine.Random.Range(1, 64);
            numberText.text = "您心中所想數字是" + number;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        numberText.text = "您心中所想數字是" + totalAnswer;
        
        replayButton.gameObject.SetActive(true);
        
        //gameObject.SetActive(false);
    }

}
