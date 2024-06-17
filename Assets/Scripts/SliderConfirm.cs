using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderConfirm : MonoBehaviour
{

    public TMP_Text NumberText;
    int _number;


    private void Start()
    {
        _number = 0;
        NumberText = GameObject.Find("Answer").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        NumberText.text = "您心中所想數字為 :" +  _number.ToString();
    }

    public void Slider1(float n)
    {
        Debug.Log(n);
        if(n == 1)
        {
            _number += 1;
        }
        else if (n == 0)
        {
            _number -= 1;
        }

    }

    public void Slider2(float n)
    {
        Debug.Log(n);
        if (n == 1)
        {
            _number += 2;
        }
        else if (n == 0)
        {
            _number -= 2;
        }
    }

    public void Slider3(float n)
    {
        Debug.Log(n);
        if (n == 1)
        {
            _number += 4;
        }
        else if (n == 0)
        {
            _number -= 4;
        }
    }

    public void Slider4(float n)
    {
        Debug.Log(n);
        if (n == 1)
        {
            _number += 8;
        }
        else if (n == 0)
        {
            _number -= 8;
        }
    }

    public void Slider5(float n)
    {
        Debug.Log(n);
        if (n == 1)
        {
            _number += 16;
        }
        else if (n == 0)
        {
            _number -= 16;
        }
    }

    public void Slider6(float n)
    {
        Debug.Log(n);
        if (n == 1)
        {
            _number += 32;
        }
        else if (n == 0)
        {
            _number -= 32;
        }
        Debug.Log(_number);
    }




}
