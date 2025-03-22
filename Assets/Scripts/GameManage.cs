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
    [SerializeField] List<�Ϥ�> image;
    [SerializeField] List<Button> checkbox;

    [SerializeField] NextButton nextButton;
    [SerializeField] TextMeshProUGUI numberText , wrongMsgText;
    [SerializeField] GameObject bottomObj;

    [SerializeField] Button replayButton;

    [SerializeField] Button leftButton , rightButton;
    int index = 0;

    private void Start()
    {
        CheckBoxAction();
        NextButtonAction();
        replayButton.onClick.AddListener(() => { SceneManager.LoadScene("MainScene"); });

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

    private void CheckBoxAction()
    {
        for (int i = 0; i < image.Count; i++)
        {

            image[i].Setup(i, false);
            int currentIndex = i; // �]�����]�Ai �O�b�j��~���w�q���ܼơA��ƥ�Ĳ�o�ɡA���|�ϥη�e�� i �ȡA�Ӥ��O�ƥ�K�[�ɪ� i ��
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

}
