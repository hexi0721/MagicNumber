using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class 圖片 : MonoBehaviour
{

    [SerializeField] int index;
    [SerializeField] bool checkBoxisOn;

    public void Setup(int index , bool checkBoxisOn)
    {
        this.index = index;
        this.checkBoxisOn = checkBoxisOn;
    }

    public void SetCheckBoxisOn(bool checkBoxisOn)
    {
        this.checkBoxisOn = checkBoxisOn;
    }

    public bool GetCheckBoxisOn()
    {
        return checkBoxisOn;
    }

    public int GetIndex()
    {
        return index;
    }

}
