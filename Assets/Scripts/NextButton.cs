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

        // �p�G���b 1 ~ 63 ����
        if (totalAnswer < 1 || totalAnswer > 63)
        {
            wrongMsgText.gameObject.SetActive(true);
            return;
        }
        else
        {
            numberText.gameObject.SetActive(true);
            numberText.text = "�z�ߤ��ҷQ�Ʀr�O" + totalAnswer;
        }

        // �����@�ǫ��s�A�u�}��Replaybutton
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
