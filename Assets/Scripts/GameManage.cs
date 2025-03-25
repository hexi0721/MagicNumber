using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManage : MonoBehaviour 
{

    [SerializeField] Sprite spriteOff, spriteOn;
    [SerializeField] List<圖片> image;
    [SerializeField] List<Button> checkbox;

    [SerializeField] NextButton nextButton;
    [SerializeField] TextMeshProUGUI numberText , wrongMsgText;
    [SerializeField] GameObject bottomObj;

    [SerializeField] Button replayButton;
    [SerializeField] int firstLogin; // 0代表首次登入 ， 1代表有登入過

    [SerializeField] Button leftButton , rightButton;
    int index = 0;

    [SerializeField] Button hintButton;
    [SerializeField] 教學父件 教學父件;
    [SerializeField] Image 教學動畫進行時禁止其他UI動作;

    private void Start()
    {
        Application.targetFrameRate = 60;

        CheckBoxAction();
        NextButtonAction();

        
        replayButton.onClick.AddListener(() => 
        {
            SceneManager.LoadScene("MainScene"); 
        });

        RightButtonAction();
        LeftButtonAction();

        教學模式Aciton();


    }

    private void CheckBoxAction()
    {
        for (int i = 0; i < image.Count; i++)
        {

            image[i].Setup(i, false);
            int currentIndex = i; // 因為閉包，i 是在迴圈外部定義的變數，當事件觸發時，它會使用當前的 i 值，而不是事件添加時的 i 值
            checkbox[currentIndex].onClick.AddListener(() =>
            {
                bool checkBoxisOn = !image[currentIndex].GetCheckBoxisOn();
                image[currentIndex].SetCheckBoxisOn(checkBoxisOn);


                Image imageCheckBox = checkbox[currentIndex].GetComponent<Image>();
                imageCheckBox.sprite = image[currentIndex].GetCheckBoxisOn() ? spriteOn : spriteOff;

            });

        }
    }

    private void NextButtonAction()
    {

        nextButton.SetUp(numberText, wrongMsgText, bottomObj , replayButton);
        nextButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            int totalAnswer = 0;
            for (int i = 0; i < image.Count; i++)
            {

                if (image[i].GetCheckBoxisOn())
                {
                    totalAnswer += Mathf.RoundToInt(Mathf.Pow(2.0f, image[i].GetIndex()));

                }

            }

            nextButton.GetTotalAnswer(totalAnswer);
            nextButton.AfterCalcute();

        });
    }

    private void RightButtonAction()
    {
        rightButton.onClick.AddListener(() =>
        {
            image[index].gameObject.SetActive(false);
            checkbox[index].gameObject.SetActive(false);

            index += 1;
            if (index > 5)
                index = 5;

            image[index].gameObject.SetActive(true);
            checkbox[index].gameObject.SetActive(true);


        });
    }

    private void LeftButtonAction()
    {
        leftButton.onClick.AddListener(() =>
        {
            image[index].gameObject.SetActive(false);
            checkbox[index].gameObject.SetActive(false);

            index -= 1;
            if (index < 0)
                index = 0;

            image[index].gameObject.SetActive(true);
            checkbox[index].gameObject.SetActive(true);


        });
    }

    private void 教學模式Aciton()
    {
        firstLogin = PlayerPrefs.GetInt("firstLogin", 0);
        int childIndex = 4;
        教學父件.SetUp(childIndex, 教學動畫進行時禁止其他UI動作 , firstLogin);
        hintButton.onClick.AddListener(() =>
        {

            教學父件.gameObject.SetActive(true);
            教學父件.動畫出現(childIndex);
        });
    }

}
