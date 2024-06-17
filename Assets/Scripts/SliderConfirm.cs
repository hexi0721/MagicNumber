using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderConfirm : MonoBehaviour
{

    public TMP_Text NumberText;
    static float _number;


    private void Start()
    {
        _number = 0;
        NumberText = GameObject.Find("Answer").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        NumberText.text = "您心中所想數字為 :" +  _number.ToString();
    }

    public void Slider(float n)
    {
        
        switch (n)
        {
            case 0:
                _number -= Mathf.Pow(2.0f, (GameManage.index));
                break;

            case 1:
                _number += Mathf.Pow(2.0f, (GameManage.index));
                break;
        }

    }





}
