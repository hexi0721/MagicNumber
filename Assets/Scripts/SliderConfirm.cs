using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderConfirm : MonoBehaviour
{

    Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public void Toggles()
    {
        /*
        switch (toggle.isOn)
        {
            case false:
                GameManage.number -= Mathf.Pow(2.0f, (GameManage.index));
                break;

            case true:
                GameManage.number += Mathf.Pow(2.0f, (GameManage.index));
                break;
        }
        */
    }



}
