using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextButton : MonoBehaviour
{


    [SerializeField] GameObject wrongMsg;
    [SerializeField] TMP_Text NumberText;
    [SerializeField] GameObject Bottom;

    // [SerializeField] GameManage gameManage;
    [SerializeField] List<�Ϥ�> ImgaeList;
    [SerializeField] int number;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(DisableAll);
        NumberText.gameObject.SetActive(false);
        number = 0;
    }

    public void DisableAll() 
    {
        /*
        foreach(�Ϥ� image in ImgaeList)
        {
            if (image.manager.checkBoxisOn)
            {
                number += Mathf.RoundToInt(Mathf.Pow(2.0f, image.manager.index));
            }
        }
        */

        if (!ImgaeList[0].manager.checkBoxisOn)
        {
            number += Mathf.RoundToInt(Mathf.Pow(2.0f, ImgaeList[0].manager.index));
        }


        // �p�G���b 1 ~ 63 ����
        if (number < 1 || number > 63)
        {
            wrongMsg.SetActive(true);
            return;
        }

        NumberText.gameObject.SetActive(true);
        NumberText.text = "�z�ߤ��ҷQ�Ʀr�O" + number;


        int BottomChildCount = Bottom.transform.childCount;
        for (int i = 0;i < BottomChildCount;i++)
        {
            Bottom.transform.GetChild(i).gameObject.SetActive(false);
        }

        gameObject.SetActive(false);

    }


}
