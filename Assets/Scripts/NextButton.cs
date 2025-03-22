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
        else
        {
            numberText.gameObject.SetActive(true);
            numberText.text = "您心中所想數字是" + totalAnswer;
        }

        // 關掉一些按鈕，只開啟Replaybutton
        int BottomChildCount = bottomObj.transform.childCount;
        for (int i = 0; i < BottomChildCount; i++)
        {
            bottomObj.transform.GetChild(i).gameObject.SetActive(false);
        }
        hintButtonObj.SetActive(false);
        replayButton.gameObject.SetActive(true);
        gameObject.SetActive(false);

    }


}
